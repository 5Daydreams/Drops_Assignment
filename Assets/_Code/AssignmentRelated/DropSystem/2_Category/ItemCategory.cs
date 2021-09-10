using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/Category")]
    public class ItemCategory : ScriptableObject
    {
        public List<GameObject> ItemBases;
    }
}