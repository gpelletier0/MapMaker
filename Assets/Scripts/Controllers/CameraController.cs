using UnityEngine;

namespace Controllers
{
    public class CameraController : MonoBehaviour
    {
        [Header("Rotation")]
        public float rotSpeed = 10f;

        public float rotMin;
        public float rotMax = 80f;

        [Header("Zoom")]
        public float zoomSpeed = 50f;

        public Vector2 zoomBounds = new Vector2(2.0f, 10.0f);

        [Header("Edge Scrolling")]
        public bool edgeScrolling = true;

        public float borderWidth = 10f;

        [Header("Mouse")]
        public float panSpeed = 20f;

        private float _mouseX;
        private float _mouseY;

        [Header("Bounds")]
        public Vector2 moveMinBounds = new Vector2(0f, 0f);
        public Vector2 moveMaxBounds = new Vector2(64f, 64f);

        private Transform cameraTransform;

        private void Start()
        {
            if (Camera.main is { })
            {
                cameraTransform = Camera.main.transform;
            }
            else
            {
                Debug.LogError("No main camera");
                gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            Movement();
            Rotation();
            Zoom();
            BoundsCheck();
        }

        /// <summary>
        /// Set's the camera position
        /// </summary>
        /// <param name="position">vector 3 position</param>
        public void SetCameraPosition(Vector3 position) =>
            cameraTransform.position = new Vector3(position.x, zoomBounds.x, position.z);

        /// <summary>
        /// Clamps the transform position to bounds
        /// </summary>
        private void BoundsCheck()
        {
            cameraTransform.position = new Vector3(
                Mathf.Clamp(cameraTransform.position.x, moveMinBounds.x, moveMaxBounds.x),
                Mathf.Clamp(cameraTransform.position.y, zoomBounds.x, zoomBounds.y),
                Mathf.Clamp(cameraTransform.position.z, moveMinBounds.y, moveMaxBounds.y));
        }

        /// <summary>
        /// Move the camera transform from keys
        /// </summary>
        void Movement()
        {
            Vector3 pos = cameraTransform.position;
            Vector3 forward = cameraTransform.forward;
            Vector3 right = cameraTransform.right;

            right.y = 0;
            forward.y = 0;
            right.Normalize();
            forward.Normalize();

            if (Input.GetKey(KeyCode.W) || edgeScrolling && Input.mousePosition.y >= Screen.height - borderWidth)
                pos += forward * panSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.S) || edgeScrolling && Input.mousePosition.y <= borderWidth)
                pos -= forward * panSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.D) || edgeScrolling && Input.mousePosition.x >= Screen.width - borderWidth)
                pos += right * panSpeed * Time.deltaTime;
            if (Input.GetKey(KeyCode.A) || edgeScrolling && Input.mousePosition.x <= borderWidth)
                pos -= right * panSpeed * Time.deltaTime;

            cameraTransform.position = pos;
        }

        /// <summary>
        /// Rotate the camera transform from mouse axis
        /// </summary>
        void Rotation()
        {
            if (Input.GetMouseButton(1))
            {
                _mouseX += Input.GetAxis("Mouse X") * rotSpeed;
                _mouseY -= Input.GetAxis("Mouse Y") * rotSpeed;
                _mouseY = Mathf.Clamp(_mouseY, rotMin, rotMax);

                cameraTransform.rotation = Quaternion.Euler(_mouseY, _mouseX, 0);
            }
        }

        /// <summary>
        /// Zoom in or out from mouse scroll wheel axis
        /// </summary>
        void Zoom()
        {
            Vector3 camPos = cameraTransform.position;
            float distance = cameraTransform.position.y;

            if (Input.GetAxis("Mouse ScrollWheel") > 0f && distance > zoomBounds.x)
                camPos += cameraTransform.forward * zoomSpeed * Time.deltaTime;
            if (Input.GetAxis("Mouse ScrollWheel") < 0f && distance < zoomBounds.y)
                camPos -= cameraTransform.forward * zoomSpeed * Time.deltaTime;

            cameraTransform.position = camPos;
        }
    }
}