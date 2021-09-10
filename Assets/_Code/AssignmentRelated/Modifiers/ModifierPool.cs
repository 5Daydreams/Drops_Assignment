using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierHolder")]
    public class ModifierPool : ScriptableObject
    {
        public List<ModifierHolder> Holders;
    }
}