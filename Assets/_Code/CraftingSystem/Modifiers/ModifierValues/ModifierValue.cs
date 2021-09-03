using _Code.ModifierOperations;
using UnityEngine;

namespace _Code
{
    
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue")]
    public class ModifierValue : ScriptableObject
    {
        // protected int tier;
        public ModifierValueInfo ModValueInfoOperation;
        public StatValue ModTargetStat;
    }
    
}