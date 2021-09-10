using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using UnityEngine;

public abstract class InventoryItemBase : MonoBehaviour
{
    public string Name;
    public Sprite InventoryIcon;

    public abstract void UseItem();
}
