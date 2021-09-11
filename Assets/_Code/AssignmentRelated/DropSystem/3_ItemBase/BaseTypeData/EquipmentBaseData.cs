using System.Collections.Generic;
using _Code.AssignmentRelated.Modifiers;
using _Code.AssignmentRelated.Modifiers.ModifierValues;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    [CreateAssetMenu(menuName = "ItemDropPool/EquipmentBase")]
    public class EquipmentBaseData : ScriptableObject
    {
        public List<StatValue> EquipmentLocalValues;
        public EquipmentTag EquipmentSlot;

        public ModifierPool ExplicitModPool;
    }
}