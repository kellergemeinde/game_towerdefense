using AsyncIO;
using NetMQ;
using NetMQ.Sockets;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.EventSystem
{
    public class EventManager : IDisposable
    {
        private string transportMethod = "inproc://";
        private Dictionary<string, HashSet<Action<string, object[]>>> subscriberDelegates;
        private PublisherSocket publisherSocket;
        private HashSet<BackgroundWorker> workers;

        public EventManager()
        {
            ForceDotNet.Force();
            workers = new HashSet<BackgroundWorker>();
            publisherSocket = new PublisherSocket(transportMethod + "eventsystem");
            subscriberDelegates = new Dictionary<string, HashSet<Action<string, object[]>>>();

            Debug.Log("EventManager created");
        }
        public void SubscribeToEvent(EventTypes eventType, Action<string, object[]> delegateMethod)
        {
            var filter = eventType.ToString();
            if (!subscriberDelegates.Keys.Contains(eventType.ToString()))
            {
                lock (subscriberDelegates)
                {
                    subscriberDelegates.Add(filter, new HashSet<Action<string, object[]>>());
                    BackgroundWorker worker = new BackgroundWorker();
                    worker.WorkerSupportsCancellation = true;
                    worker.DoWork += FilteredBackgroundWorker;
                    worker.RunWorkerAsync(filter);
                    Debug.Log("Worker created for " + filter);
                }
            }
            Debug.Log("Subscribed for " + filter);
            subscriberDelegates[filter].Add(delegateMethod);
        }

        private void FilteredBackgroundWorker(object sender, DoWorkEventArgs e)
        {
            var filter = (string)e.Argument;
            using (var subscriberSocket = new SubscriberSocket())
            {
                subscriberSocket.Options.ReceiveHighWatermark = 1000;
                subscriberSocket.Connect(transportMethod + "eventsystem");
                subscriberSocket.Subscribe(filter);
                while (!e.Cancel)
                {
                    string messageTopicReceived = subscriberSocket.ReceiveFrameString();
                    byte[] message = subscriberSocket.ReceiveFrameBytes();
                    var eventMessage = EventMessage.Create(message);

                    Debug.Log("Event received for " + filter + "|" + messageTopicReceived);

                    foreach (var actionDelegate in subscriberDelegates[filter])
                    {
                        try
                        {
                            actionDelegate.Invoke(eventMessage.Sender, eventMessage.Parameter);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }

        public void Send(string sender, EventTypes eventType, params object[] parameter)
        {
            lock (publisherSocket)
            {
                publisherSocket.SendMoreFrame(eventType.ToString()).SendFrame(EventMessage.Create(sender, parameter).GetBytes());
                Debug.Log("Event send for " + eventType.ToString());
            }
            //Thread asyncSendingThread = new Thread(() =>
            //{
            //    lock (localInstance.publisherSocket)
            //    {
            //        localInstance.publisherSocket.SendMoreFrame(eventType.ToString()).SendFrame(EventMessage.Create(sender, parameter).GetBytes());
            //        Debug.Log("Event send for " + eventType.ToString());
            //    }
            //});
            //asyncSendingThread.Start();
        }

        public void Send(GameObject sender, EventTypes eventType, params object[] parameter)
        {
            Send(sender.name, eventType, parameter);
        }

        public void Dispose()
        {
            if (subscriberDelegates != null)
            {
                lock (subscriberDelegates)
                {
                    subscriberDelegates = new Dictionary<string, HashSet<Action<string, object[]>>>();
                }
            }
            foreach (var worker in workers)
            {
                worker.CancelAsync();
            }
            publisherSocket.Close();
        }
    }
}