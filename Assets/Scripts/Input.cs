using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Project{

    public class Input{

        private static Input instance;

        private Input(){}

        public static Input Instance{
            get{
                if (instance == null){
                    instance = new Input();
                }
                return instance;
            }
        }

        public Vector3 MouseWorldPosition{
            get{
                RaycastHit hit;
                UnityEngine.Camera cam = UnityEngine.Camera.main;
                if (!cam) {
                    Debug.LogError("Input.MouseWorldPosition: Main camera not found!");
                    return Vector3.zero;
                }
                Ray ray = cam.ScreenPointToRay(UnityEngine.Input.mousePosition);

                if (Physics.Raycast(ray, out hit)){
                    return hit.point;
                }
                return Vector3.zero;
            }
        }

        public Vector2 MouseScreenPosition{
            get{
                Vector3 MousePosition = UnityEngine.Input.mousePosition;
                return new Vector2(MousePosition.x, MousePosition.y);
            }
        }
   
    }
}
