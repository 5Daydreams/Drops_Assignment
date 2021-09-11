using System.Collections.Generic;
using _Code.AssignmentRelated.DropSystem._3_ItemBase.BaseTypeData;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._2_Category
{
    [CreateAssetMenu(menuName = "ItemDropPool/Category")]
    public class ItemCategory : ScriptableObject
    {
        public List<InventoryItemBase> ItemBases;
    }
}