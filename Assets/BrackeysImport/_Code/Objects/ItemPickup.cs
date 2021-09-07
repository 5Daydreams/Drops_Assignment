using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using UnityEngine;

[Serializable]
public class ItemPickup : Interactable
{
    public Item item;
    public override void Interact()
    {
        base.Interact();

        Pickup();
    }

    void Pickup()
    {
        if (Inventory.instance.AddItem(item))
        {
            Destroy(gameObject);
        }
    }
}
