using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierPool")]
    public class ModifierPool : ScriptableObject
    {
        public List<ModifierGroup> Holders;
    }
}