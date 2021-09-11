using _Code.AssignmentRelated.DropSystem._3_ItemBase;
using UnityEngine;

namespace BrackeysImport._Code.Inventory.Items
{
    [CreateAssetMenu(menuName = "Inventory/Equipment")]
    public class Equipment : Item
    {
        public EquipmentTag equipSlot;
        public int armorModifier;
        public int damageModifier;

        public override void UseItem()
        {
            base.UseItem();
            // EquipmentManager.instance.Equip(this);
            // RemoveFromInventory();
        }
    }
}

// public enum EquipmentSlot { Head, Chest, Legs, Weapon, Shield, Gloves, Feet }