using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project
{

    public class Input
    {
        private static Input instance;

        private Vector3 mouseWorldPosition;

        private Input(){}

        public static Input Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Input();
                }
                return instance;
            }
        }

        public Vector3 MouseWorldPosition
        {
            get
            {
                return mouseWorldPosition;
            }
        }

        public Vector2 MouseGridPosition
        {
            get
            {
                return new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
            }
        }

    
        //This is no callback and has to be invoked by another script
        public void Update()
        {
            RaycastHit hit;
            UnityEngine.Camera cam = UnityEngine.Camera.main;
            if (!cam)
            {
                Debug.LogError("Input.MouseWorldPosition: Main camera not found!");
                mouseWorldPosition =  Vector3.zero;
            }
            Ray ray = cam.ScreenPointToRay(UnityEngine.Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                mouseWorldPosition =  hit.point;
            }
            mouseWorldPosition =  Vector3.zero;
        }
   
    }
}
