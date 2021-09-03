using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/BaseStats/Armour")]
    public class ArmourStats : EquipmentStats
    {
        public StatValue<int> Armour;
        public StatValue<int> Evasion;
        public StatValue<int> EnergyShield;
    }
}