using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/BaseStats/Weapon")]
    public class WeaponStats : EquipmentStats
    {
        public List<StatValue<int>> WeaponIntStats;
        public List<StatValue<float>> WeaponFloatStats;
    }
}