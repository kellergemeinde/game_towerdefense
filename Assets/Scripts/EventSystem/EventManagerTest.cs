using Assets.Scripts.EventSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManagerTest : MonoBehaviour {

    public EventManager TestEventManager { get; set; }

    // Use this for initialization
    void Start () {
        TestEventManager = EventSystem.GetManager();
        TestEventManager.SubscribeToEvent(EventTypes.UnitSpawned, ExampleMethod);
	}

    private void ExampleMethod(string arg1, object[] arg2)
    {
        Debug.Log("TestMethodInvoked");
    }

    // Update is called once per frame
    void Update () {
        TestEventManager.Send(gameObject, EventTypes.UnitSpawned, new object[] { "Test" });
	}

    private void OnDestroy()
    {
        TestEventManager.Dispose();
    }
}
