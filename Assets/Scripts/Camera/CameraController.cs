using UnityEngine;

namespace Project.Camera
{

    public class CameraController : Behaviour
    {
        public Vector2 target;
        public bool enableCameraMouseMovement = true;
        float panSpeed = 100f;
        float panBorderThickness = 10f;
        float zoomSpeed = 2000;
        public float smoothTime = 0.3F;
        float minZoom = 10;
        float maxZoom = 1000;
    private Vector3 velocity = Vector3.zero;

        void Update()
        {
            if (UnityEngine.Input.GetKey(KeyCode.Space)) //TODO Project->Edit->Inputsettings?
            {
                transform.RotateAround(target, new Vector3(0.0f, 1.0f, 0.0f), 20 * Time.deltaTime * 10);
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
            currentPosition.y -= scroll * panSpeed;
            currentPosition.y = Mathf.Clamp(currentPosition.y, minZoom, maxZoom);

            transform.position = Vector3.SmoothDamp(transform.position, currentPosition, ref velocity, smoothTime);
        }

    }

}
