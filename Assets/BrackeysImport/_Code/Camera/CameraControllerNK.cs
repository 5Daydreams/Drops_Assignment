using UnityEngine;

namespace _Code.Camera
{
    public class CameraControllerNK : MonoBehaviour
    {
        [Header("Settings - references")] 
        [SerializeField] private Transform targetToFollow;
        [SerializeField] private float baseRadius;
        private Vector3 finalOffset;

        [Header("Settings - zoom")] 
        [SerializeField] private float minZoom = 1.0f;
        [SerializeField] private float maxZoom = 4.0f;
        [SerializeField] private float zoomSpeed = 10.0f;
        private float currentZoom = 10.0f;

        [Header("Settings - pitch")]
        [SerializeField] private float pitchProportion = 2.0f;
        [SerializeField] private float pitch = 1.5f;

        [Header("Settings - Vertical Angle")] 
        [SerializeField] private bool flipVertical = false;
        [SerializeField] private float pitchAngleSpeed = 30.0f;
        [SerializeField] private float minPitchAngle = 1.0f;
        [SerializeField] private float maxPitchAngle = 3.0f;
        private float currPitchAngle = 2.0f;

        [Header("Settings - Horizontal Angle")]
        [SerializeField] private bool flipHorizontal = false;
        [SerializeField] private float yawSpeed = 100.0f;
        [SerializeField] private float yawSpeedMouse = 70.0f;
        private float currentYaw = 0.0f;
        
        private Vector3 lastMousePos;


        private void Update()
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);

            currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

            Vector3 drag = (Input.mousePosition - lastMousePos);

            if (Input.GetMouseButton(1) && drag.sqrMagnitude > 1.5f)
            {
                currentYaw += drag.x * yawSpeedMouse * Time.deltaTime;
                
                currPitchAngle -= drag.y * pitchAngleSpeed * Time.deltaTime;
                currPitchAngle = Mathf.Clamp(currPitchAngle, minPitchAngle, maxPitchAngle);
            }
            
            Quaternion rotation = Quaternion.AngleAxis(currPitchAngle,Vector3.left);

            float radius = baseRadius * currentZoom;

            finalOffset = rotation * Vector3.forward * radius;

            lastMousePos = Input.mousePosition;
        }

        // Update is called once per frame
        void LateUpdate()
        {
            transform.position = targetToFollow.position + finalOffset * currentZoom + Vector3.up * pitch;
            transform.LookAt(targetToFollow.position + Vector3.up * pitchProportion * pitch);

            transform.RotateAround(targetToFollow.position, Vector3.up, currentYaw);
        }
    }
}