using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EventSystem
{
    public class EventSystem : MonoBehaviour {

        private EventManager eventManager;

        // Use this for initialization
        void Awake() {
            eventManager = new EventManager();
        }

        public EventManager GetEventManager()
        {
            return eventManager;
        }

        public static EventManager GetManager()
        {
            var eventSystem = GameObject.FindObjectOfType<EventSystem>();
            if (eventSystem != null)
            {
                return eventSystem.GetEventManager();
            }
            return null;
        }
    }
}