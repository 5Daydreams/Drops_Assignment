using System.Collections.Generic;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData
{
    [CreateAssetMenu(menuName = "ItemDropPool/RarityPool")] 
    public class RarityPoolGroup :  ScriptableObject
    {
        public List<ItemRarity> RarityTiers;
    }
}