using _Code.Objects;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Code.ControllerScripts.Player
{
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private LayerMask _movementMask;
        [SerializeField] private Interactable _focus;

        private UnityEngine.Camera _cam;
        private PlayerMotor _motor;

        void Start()
        {
            _cam = UnityEngine.Camera.main;
            _motor = GetComponent<PlayerMotor>();
        }

        void Update()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
        
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100, _movementMask))
                {
                    _motor.MoveToPoint(hit.point);

                    RemoveFocus();
                }
            }
        
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = _cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                
                    if(interactable != null )
                    {
                        SetFocus(interactable);
                    }
                }
            }
        
            this.transform.GetChild(0).transform.localPosition = Vector3.zero;
        }

        void SetFocus(Interactable newFocus)
        {
            if (newFocus != _focus)
            {
                if (_focus != null)
                    _focus.OnFocused(null);
            
                _focus = newFocus;
                _motor.FollowTarget(newFocus);    
            }
        
            newFocus.OnFocused(transform);
        }

        void RemoveFocus()
        {
            if (_focus != null)
                _focus.OnFocused(null);
        
            _focus = null;
            _motor.StopFollowingTarget();
        }
    }
}