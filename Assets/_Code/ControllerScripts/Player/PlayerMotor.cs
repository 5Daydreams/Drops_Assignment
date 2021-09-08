using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    public Transform Target;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Target != null)
        {
            _agent.SetDestination(Target.position);
            FaceTarget();
        }
    }

    void FaceTarget()
    {
        Vector3 direction = (Target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x,0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, 5.0f*Time.deltaTime);
    }

    public void MoveToPoint(Vector3 point)
    {
        _agent.SetDestination(point);
    }

    public void FollowTarget(Interactable newTarget)
    {
        _agent.stoppingDistance = newTarget.InteractRadius;
        _agent.updateRotation = false;
        Target = newTarget.interactionTransform;
    }

    public void StopFollowingTarget()
    {
        _agent.stoppingDistance = 0;
        _agent.updateRotation = true;
        Target = null;
    }
}
