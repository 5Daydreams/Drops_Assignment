using System;
using System.Collections.Generic;
using _Code.ModifierOperations;

namespace _Code
{
    public class EquipmentInstance : ItemInstanceBase
    {
        public ItemRarity Rarity;
        public List<ExplicitModifier> ModifierPool;
        private List<ExplicitModifierValue> RolledModValues = new List<ExplicitModifierValue>();

        public void RollExplicitModifierValues()
        {
            ExtractFromModPool();

            foreach (var modValue in RolledModValues)
            {
                return;
                //modValue.ApplyModifier();
            }
        }

        private void ExtractFromModPool()
        {
            RolledModValues.Clear();
            foreach (var mod in ModifierPool)
            {
                foreach (var modValue in mod.ModifierValues)
                {
                    RolledModValues.Add( modValue);
                }
            }
        }
    }
}