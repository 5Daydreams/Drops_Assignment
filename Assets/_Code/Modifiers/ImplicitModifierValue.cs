using UnityEngine;

namespace _Code
{
    [CreateAssetMenu(menuName = "ItemDropPool/ModifierValue/Implicit")]
    public class ImplicitModifierValue : ItemModifierValue
    {
        [Range(0.5f,2.0f)][SerializeField] private float _multiplier = 1.0f;
    }
}