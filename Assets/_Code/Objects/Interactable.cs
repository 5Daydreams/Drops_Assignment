using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable] [SerializeField]
public class Interactable : MonoBehaviour
{
    [SerializeField] protected float interactRadius = 3.0f;
    public Transform interactionTransform;
    public float InteractRadius => interactRadius;

    [SerializeField] private UnityEvent _onInteraction;
    [HideInInspector] public UnityEvent HiddenInteraction;
    
    private bool hasInteractedRecently = false;
    
    private bool isFocused = false;
    Transform player;

    private void Awake()
    {
        if (interactionTransform == null)
            interactionTransform = transform;
    }

    public void Interact()
    {
        _onInteraction.Invoke();
    }
    
    private void Update()
    {
        if (isFocused && !hasInteractedRecently)
        {
            float distance = Vector3.Distance(player.position, interactionTransform.position);
            if (distance <= interactRadius)
            {
                Interact();
                hasInteractedRecently = true;
            }
        }
    }

    public void OnFocused(Transform playerTransform)
    {
        player = playerTransform;
        isFocused = (playerTransform != null);
        hasInteractedRecently = false;
    }
    
    private void OnDrawGizmosSelected()
    {
        if (interactionTransform == null)
            interactionTransform = this.transform;
        Gizmos.DrawWireSphere(interactionTransform.position,interactRadius);
    }
}
