using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Assets.Scripts.EventSystem
{
    public class EventMessage
    {
        public string Sender { get; set; }
        public object[] Parameter { get; set; }

        public static EventMessage Create(string sender, object[] parameter)
        {
            return new EventMessage() { Sender = sender, Parameter = parameter };
        }

        public static EventMessage Create(byte[] data)
        {
            var eventMessage = new EventMessage();

            var senderLength = new byte[4];
            Array.Copy(data, 0, senderLength, 0, 4);
            var sender = new byte[BitConverter.ToInt16(senderLength, 0)];
            Array.Copy(data, 4, sender, 0, sender.Length);
            eventMessage.Sender = Encoding.Unicode.GetString(sender);

            var parameterLength = new byte[4];
            Array.Copy(data, sender.Length + 4, parameterLength, 0, 4);
            var parameter = new byte[BitConverter.ToInt16(parameterLength, 0)];
            Array.Copy(data, sender.Length + 8, parameter, 0, parameter.Length);
            BinaryFormatter binary = new BinaryFormatter();
            var stream = new MemoryStream(parameter);
            stream.Position = 0;
            eventMessage.Parameter = (object[])binary.Deserialize(stream);

            return eventMessage;
        }

        public byte[] GetBytes()
        {
            var sender = Encoding.Unicode.GetBytes(Sender);
            BinaryFormatter binary = new BinaryFormatter();
            var stream = new MemoryStream();
            binary.Serialize(stream, Parameter);
            stream.Position = 0;
            var parameter = stream.ToArray();
            var bytes = new byte[sender.Length + parameter.Length + 8];

            var senderLength = GetSize(sender);
            var parameterLength = GetSize(parameter);

            Array.Copy(senderLength, 0, bytes, 0, 4);
            Array.Copy(sender, 0, bytes, 4, sender.Length);
            Array.Copy(parameterLength, 0, bytes, 4 + sender.Length, 4);
            Array.Copy(parameter, 0, bytes, 8 + sender.Length, parameter.Length);

            return bytes;
        }

        private byte[] GetSize(byte[] byteArray)
        {
            return BitConverter.GetBytes(byteArray.Length);
        }
    }
}
