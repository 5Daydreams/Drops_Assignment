using UnityEngine;

namespace _Code
{
    public class ImplicitModifierValue : ItemModifierValue
    {
        [Range(0.5f,2.0f)][SerializeField] private float _multiplier;
    }
}