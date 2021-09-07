using System;
using System.Collections;
using System.Collections.Generic;
using _Code;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance;
    public List<Item> items = new List<Item>();
    [SerializeField] private int space;

    public delegate void OnItemChanged();

    public OnItemChanged onItemChangedCallback;

    private void Awake()
    {
        if (instance !=null)
        {
            Debug.Log("Error, multiple inventories found");
            return;
        }
        
        instance = this;
    }


    public bool AddItem(Item item)
    {
        if (!item.isDefault)
        {
            if (items.Count >= space)
            {
                Debug.Log("Not enough room");
                return false;
            }
            items.Add(item);
            onItemChangedCallback?.Invoke();
        }
        
        return true;
    }
    
    public void Remove(Item item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            onItemChangedCallback?.Invoke();
        }
    }
}
