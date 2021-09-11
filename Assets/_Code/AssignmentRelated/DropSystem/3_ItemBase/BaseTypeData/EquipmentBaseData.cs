using System.Collections.Generic;
using _Code;
using UnityEngine;

[CreateAssetMenu(menuName = "ItemDropPool/EquipmentBase")]
public class EquipmentBaseData : ScriptableObject
{
    public List<StatValue> EquipmentLocalValues;
    public EquipmentTag EquipmentSlot;

    public ModifierPool ExplicitModPool;
}