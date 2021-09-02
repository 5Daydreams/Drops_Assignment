using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/BaseStats/Armour")]
    public class ArmourStats : EquipmentStats
    {
        public int Armour;
        public int Evasion;
        public int EnergyShield;
    }
}