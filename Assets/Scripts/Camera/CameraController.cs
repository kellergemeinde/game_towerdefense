using UnityEngine;

namespace Project.Camera
{

    public class CameraController : Behaviour
    {
        public Vector2 target;
        public bool enableCameraMouseMovement = true;
        float panSpeed = 10f;
        float panBorderThickness = 10f;
        float zoomSpeed = 2000;
        float minZoom = 10;
        float maxZoom = 1000;

        Quaternion standardRotation;

        private void Awake()
        {
            standardRotation = transform.rotation;
        }

        void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.Space))
            {
               // target = Input.Instance.MouseGridPosition;
               // if (transform.rotation.eulerAngles.y < 90)
               // {
                    transform.RotateAround(target, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * 10);
               // }
            }

            Vector3 currentPosition = transform.position;

            float horizontal = UnityEngine.Input.GetAxis("Horizontal");
            float vertical = UnityEngine.Input.GetAxis("Vertical");

            Vector2 mouseScreenPosition = UnityEngine.Input.mousePosition;

            if (vertical > 0 || mouseScreenPosition.y >= Screen.height - panBorderThickness && enableCameraMouseMovement)
            {
                currentPosition.z += panSpeed * Time.deltaTime;
            }
            if (vertical < 0 || mouseScreenPosition.y <= panBorderThickness && enableCameraMouseMovement)
            {
                currentPosition.z -= panSpeed * Time.deltaTime;
            }
            if (horizontal > 0 || mouseScreenPosition.x >= Screen.width - panBorderThickness && enableCameraMouseMovement)
            {
                currentPosition.x += panSpeed * Time.deltaTime;
            }
            if (horizontal < 0 || mouseScreenPosition.x <= panBorderThickness && enableCameraMouseMovement)
            {
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
