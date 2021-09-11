using System.Collections.Generic;
using UnityEngine;

namespace _Code.AssignmentRelated.DropSystem._2_Category
{
    [CreateAssetMenu(menuName = "ItemDropPool/Category")]
    public class ItemCategory : ScriptableObject
    {
        public List<GameObject> ItemBases;
    }
}