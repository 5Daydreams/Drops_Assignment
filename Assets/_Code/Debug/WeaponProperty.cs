using System.Collections.Generic;
using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "EquipmentProperties/One Handed Sword")]
    public class WeaponProperty : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public WeaponStats stats;
        public ImplicitModifier Implicit;
        // public List<ExplicitModifier> ExplicitModifiers;
    }
}