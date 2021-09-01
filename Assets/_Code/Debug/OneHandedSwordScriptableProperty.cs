using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "EquipmentProperties/One Handed Sword")]
    public class OneHandedSwordScriptableProperty : ScriptableObject
    {
        public string Name;
        public Sprite Sprite;
        public SwordStats Stats;
        public ImplicitModifierValue Implicit;
    }
}