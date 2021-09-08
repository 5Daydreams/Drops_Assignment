using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using UnityEngine;

public abstract class InventoryItemBaseData : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    
    public virtual void UseItem()
    {
        
    }
}
