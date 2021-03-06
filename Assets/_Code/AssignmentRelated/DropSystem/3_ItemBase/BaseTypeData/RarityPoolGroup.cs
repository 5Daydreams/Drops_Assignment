using System;
using System.Collections.Generic;
using FG_Toolbox.MathExtensions;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    [CreateAssetMenu(menuName = "ItemDropPool/RarityPool")] 
    public class RarityPoolGroup :  ScriptableObject
    {
        public List<ItemRarity> RarityTiers;
    }
    
    [Serializable] 
    public class ItemRarity
    {
        public Color RarityColor = Color.white;
        public int MinModSlots = 0;
        public int MaxModSlots = 2;

        public int GetModCountFromRarity()
        {
            return Random.Range(MinModSlots, MaxModSlots + 1);
        }

        public void RerollRarity(RarityPoolGroup rarityPoolGroup)
        {
            ItemRarity newRarity = rarityPoolGroup.RarityTiers.GetRandomElement();
            
            this.RarityColor = newRarity.RarityColor;
            this.MinModSlots = newRarity.MinModSlots;
            this.MaxModSlots = newRarity.MaxModSlots;
        }
    }
}