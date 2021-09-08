using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<InventoryItemBaseData> items = new List<InventoryItemBaseData>();
    [SerializeField] private int space;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Error, multiple inventories found");
            return;
        }

        instance = this;
    }

    public bool AddItem(InventoryItemBaseData item)
    {
        if (items.Count >= space)
        {
            Debug.Log("Not enough room");
            return false;
        }

        items.Add(item);
        onItemChangedCallback?.Invoke();

        return true;
    }

    public void Remove(InventoryItemBaseData item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            onItemChangedCallback?.Invoke();
        }
    }
}