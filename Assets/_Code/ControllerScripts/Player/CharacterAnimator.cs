using UnityEngine;
using UnityEngine.AI;

namespace _Code.ControllerScripts.Player
{
    public class CharacterAnimator : MonoBehaviour
    {
        [SerializeField] private float animationSmoothTime = 0.1f;
        private Animator animator;

        NavMeshAgent agent;

          void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            animator = GetComponentInChildren<Animator>();
        }

         void Update()
        {
            float speedPercent = agent.velocity.magnitude / agent.speed;
            animator.SetFloat("speedPercent",speedPercent,animationSmoothTime,Time.deltaTime);
        }
    }
}