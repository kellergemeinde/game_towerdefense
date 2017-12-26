using UnityEngine;

namespace Project.Camera {

    public class CameraController : Behaviour {

        float panSpeed = 10f;
        float panBorderThickness = 10f;
        float zoomSpeed = 2000;
        float minZoom = 10;
        float maxZoom = 1000;

        void Update() {
            Vector3 currentPosition = transform.position;

            float horizontal = UnityEngine.Input.GetAxis("Horizontal");
            float vertical = UnityEngine.Input.GetAxis("Vertical");

            Vector2 mouseScreenPosition = UnityEngine.Input.mousePosition;

            if (vertical > 0 || mouseScreenPosition.y >= Screen.height - panBorderThickness){
                currentPosition.z += panSpeed * Time.deltaTime;
            }
            if (vertical < 0 || mouseScreenPosition.y <= panBorderThickness){
                currentPosition.z -= panSpeed * Time.deltaTime;
            }
            if (horizontal > 0 || mouseScreenPosition.x >= Screen.width - panBorderThickness){
                currentPosition.x += panSpeed * Time.deltaTime;
            }
            if (horizontal < 0 || mouseScreenPosition.x <= panBorderThickness){
                currentPosition.x -= panSpeed * Time.deltaTime;
            }

            //Zoom
            float scroll = UnityEngine.Input.GetAxis("Mouse ScrollWheel");
            currentPosition.y -= scroll * zoomSpeed * Time.deltaTime;
            currentPosition.y = Mathf.Clamp(currentPosition.y, minZoom, maxZoom);
            
            transform.position = currentPosition;
        }

    }

}
