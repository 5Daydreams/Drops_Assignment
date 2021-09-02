using System;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/BaseStats/Weapon")]
    public class WeaponStats : EquipmentStats
    {
        public int MinDamage;
        public int MaxDamage;
        public float CriticalStrikeChance;
        public float AttacksPerSecond;
        public int Range;
    }
}