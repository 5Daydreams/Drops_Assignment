using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using _Code.Extensions;
using UnityEngine;

[Serializable]
public class EquipmentSlot
{
    public EquipmentTag EquipmentSlotType;
    public EquipmentBaseData EquippedItem;
}


public class EquipmentManager : MonoBehaviour
{
    public static EquipmentManager instance;

    [Tooltip("Must contain all VALID slots before playmode")] [SerializeField]
    private EquipmentSlot[] currentEquipment;
    [SerializeField] private string unequipAllKey = "u";

    private Inventory inventory;

    public delegate void OnEquipmentChanged(EquipmentBaseData newItem, EquipmentBaseData oldItem);

    public OnEquipmentChanged onEquipmentChanged;

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < currentEquipment.Length; i++)
        {
            var currSlot = currentEquipment[i];
            if (currSlot.EquipmentSlotType == null)
            {
                throw new NullReferenceException("Empty slot type found in equip manager");
            }
        }
    }


    private void Start()
    {
        inventory = Inventory.instance;
    }

    public void Equip(EquipmentBaseData newItem)
    {
        // Find the tag you want to equip the new item at;
        EquipmentTag itemTag = newItem.EquipmentSlot;

        // Assume there might not be an empty slot of the given tag
        EquipmentSlot validSlot = null;
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            EquipmentSlot equip = currentEquipment[i];
            // check for slots that match the newItem's tag and are empty
            if (equip.EquipmentSlotType == itemTag && equip.EquippedItem == null)
            {
                validSlot = equip;
            }
        }

        // if no valid slots found, remove something first
        if (validSlot == null)
        {
            EquipmentSlot firstTaggedSlot = currentEquipment.First(slot => slot.EquipmentSlotType == itemTag);
            inventory.AddItem(firstTaggedSlot.EquippedItem);
            firstTaggedSlot.EquippedItem = null;
            validSlot = firstTaggedSlot;
        }

        // open slot is now available - insert new item
        validSlot.EquippedItem = newItem;

        inventory.Remove(newItem);
        onEquipmentChanged?.Invoke(newItem, validSlot?.EquippedItem);
    }

    public void Unequip(EquipmentTag slotTag)
    {
        // check the valid slots and the base data for open slots of the supplied type

        EquipmentSlot correspondingEquipment = null;
        
        for (int i = 0; i < currentEquipment.Length; i++)
        {
            EquipmentSlot equip = currentEquipment[i];
            // check for slots that match the newItem's tag and are empty
            if (equip.EquipmentSlotType == slotTag && equip.EquippedItem == null)
            {
                correspondingEquipment = equip;
            }
        }

        if (correspondingEquipment == null)
        {
            return; // nothing to be done, there were no items of that tag equipped
        }

        inventory.AddItem(correspondingEquipment.EquippedItem);
        correspondingEquipment.EquippedItem = null;
        
        onEquipmentChanged?.Invoke(null, correspondingEquipment.EquippedItem);
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
            if (equip.EquippedItem == null)
            {
                continue;
            }

            inventory.AddItem(equip.EquippedItem);
            equip.EquippedItem = null;
            onEquipmentChanged?.Invoke(null, equip.EquippedItem);
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