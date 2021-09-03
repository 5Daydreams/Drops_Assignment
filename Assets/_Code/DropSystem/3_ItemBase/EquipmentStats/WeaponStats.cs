using System;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/BaseStats/Weapon")]
    public class WeaponStats : EquipmentStats
    {
        public StatValue<int> MinDamage;
        public StatValue<int> MaxDamage;
        public StatValue<float> CriticalStrikeChance;
        public StatValue<float> AttacksPerSecond;
        public StatValue<int> Range;
    }
}