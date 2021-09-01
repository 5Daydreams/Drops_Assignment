using UnityEngine;

namespace _Code
{
    public class ExplicitModifierValue : ItemModifierValue
    {
        [Range(0.5f, 2.0f)] [SerializeField] private float _multiplier = 1.0f;
    }
}