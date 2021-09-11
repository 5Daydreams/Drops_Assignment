using UnityEngine;
using UnityEngine.AI;

namespace _Code.ControllerScripts
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class EnemyController : MonoBehaviour
    {
        public float lookRadius = 10.0f;


        private Transform target;
        private NavMeshAgent agent;


        private void Start()
        {
            target = PlayerSingleton.instance.player.transform;
            agent = GetComponent<NavMeshAgent>();
        }

        private void Update()
        {
            float distance = Vector3.Distance(target.position, transform.position);
            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);

                if (distance <= agent.stoppingDistance)
                {
                    // attack target
                    FaceTarget();
                }
            }
        }

        void FaceTarget()
        {
            Vector3 directionToTarget = (target.position - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToTarget.x,0,directionToTarget.z));
            transform.rotation = Quaternion.Slerp(transform.rotation,lookRotation,Time.deltaTime);
        }
    
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position,lookRadius);
            Gizmos.color = Color.white;
        }
    }
}
