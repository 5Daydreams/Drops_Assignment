using UnityEngine;

namespace _Code.ControllerScripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        [Header("Settings - references")]
        [SerializeField] private Transform targetToFollow;
        [SerializeField] private Vector3 offset;
    
        [Header("Settings - zoom")]
        [SerializeField] private float minZoom = 1.0f;
        [SerializeField] private float maxZoom = 4.0f;
        [SerializeField] private float zoomSpeed = 10.0f;
        private float currentZoom = 10.0f;
    
        [Header("Settings - pitch")]
        [SerializeField] private float pitchProporttion = 2.0f;
        [SerializeField] private float minPitch = 1.0f;
        [SerializeField] private float maxPitch = 3.0f;
        private float pitch = 2.0f;
    
        [Header("Settings - yaw")]
        [SerializeField] private float yawSpeed = 100.0f;
        [SerializeField] private float yawSpeedMouse = 70.0f;
        private float currentYaw = 0.0f;
        private Vector3 lastMousePos;


        private void Update()
        {
            currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
            pitch -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
            pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        
            currentYaw -= Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;


            Vector3 drag = (Input.mousePosition - lastMousePos);
        
            if (Input.GetMouseButton(1) && drag.sqrMagnitude > 1.5f)
            {
                currentYaw += drag.x * yawSpeedMouse * Time.deltaTime;
                
                pitch -= drag.y * zoomSpeed * Time.deltaTime;
                pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
            }
        
            lastMousePos = Input.mousePosition;
        }
        
        void LateUpdate()
        {
            transform.position = targetToFollow.position + offset * currentZoom + Vector3.up * pitch;
            transform.LookAt(targetToFollow.position + Vector3.up * pitchProporttion * pitch);
        
            transform.RotateAround(targetToFollow.position,Vector3.up,currentYaw);
        }
    }
}
