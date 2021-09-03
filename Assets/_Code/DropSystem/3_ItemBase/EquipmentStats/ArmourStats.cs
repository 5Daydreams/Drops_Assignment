using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/BaseStats/Armour")]
    public class ArmourStats : EquipmentStats
    {
        public List<StatValue<int>> ArmourBaseStats;
    }
}