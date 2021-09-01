using System.Collections.Generic;

namespace _Code
{
    public class EquipmentBase : ItemBase
    {
        public ItemRarity Rarity;
        public EquipmentStats Stats; 
        public ImplicitModifierValue Implicit;
        public List<ExplicitModifierValue> Modifier;
    }
}