using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;
    [SerializeField] private List<EquipmentBaseData> currentEquipment;
    [SerializeField] private List<EquipmentTag> validSlots;
    private Inventory inventory;
    private string unequipAllKey = "u";

    public delegate void OnEquipmentChanged(EquipmentBaseData newItem, EquipmentBaseData oldItem);

    public OnEquipmentChanged onEquipmentChanged;

    private void Awake()
    {
        instance = this;
    }


    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void Equip(EquipmentBaseData newItem)
    {
        EquipmentBaseData oldItem = currentEquipment.Find(equip => equip.EquipmentSlot == newItem.EquipmentSlot);

        if (oldItem != null)
        {
            inventory.AddItem(oldItem);
        }
        
        currentEquipment.Add(newItem);

        onEquipmentChanged?.Invoke(newItem, oldItem);
    }

    public void Unequip(EquipmentTag slotTag)
    {
        EquipmentBaseData correspondingEquipment = currentEquipment.Find(equip => equip.EquipmentSlot == slotTag);

        if (correspondingEquipment != null)
        {
            inventory.AddItem(correspondingEquipment);
            currentEquipment.Remove(correspondingEquipment);
            onEquipmentChanged?.Invoke(null, correspondingEquipment);
        }
    }

    public void UnequipAll()
    {
        // This would be the refactoring that follows the original idea from the brackeys video,
        // but I hate it :p
        // foreach (var slot in validSlots)
        // {
        //     Unequip(slot);
        // }

        // So instead, this is how I'll do it xD
        foreach (var equip in currentEquipment)
        {
            inventory.AddItem(equip);
            currentEquipment.Remove(equip);
            onEquipmentChanged?.Invoke(null, equip);
        }
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(unequipAllKey))
        {
            UnequipAll();
        }
    }
}