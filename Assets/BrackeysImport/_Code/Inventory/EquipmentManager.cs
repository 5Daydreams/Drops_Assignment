using System;
using System.Collections;
using System.Collections.Generic;
using _Code.Interfaces;
using UnityEngine;

public class EquipmentManager : MonoBehaviour
{
   public static EquipmentManager instance;
   [SerializeField] private Equipment[] currentEquipment;
   private Inventory inventory;
   private string unequipAllKey = "u";

   public delegate void OnEquipmentChanged(Equipment newItem, Equipment oldItem);

   public OnEquipmentChanged onEquipmentChanged;
   
   private void Awake()
   {
      instance = this;
   }


   private void Start()
   {
      inventory = Inventory.instance;
      int numberOfSlots = System.Enum.GetNames(typeof(EquipmentSlot)).Length;
      currentEquipment = new Equipment[numberOfSlots];
   }

   public void Equip(Equipment newItem)
   {
      int slotIndex = (int) newItem.equipSlot;

      Equipment oldItem = null;
      
      if (currentEquipment[slotIndex] != null)
      {
         oldItem = currentEquipment[slotIndex];
         inventory.AddItem(oldItem);
      }
      
      onEquipmentChanged?.Invoke(newItem,oldItem);
      
      currentEquipment[slotIndex] = newItem;
   }

   public void Unequip(int slotIndex)
   {
      if (currentEquipment[slotIndex] != null)
      {
         Equipment oldItem = currentEquipment[slotIndex];
         inventory.AddItem(oldItem);

         currentEquipment[slotIndex] = null;
         
         onEquipmentChanged?.Invoke(null,oldItem);
      }
   }

   public void UnequipAll()
   {
      for (int i = 0; i < currentEquipment.Length; i++)
      {
         Unequip(i);
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
