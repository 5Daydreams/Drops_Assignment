using UnityEngine;

namespace OtherAssets.Environment.PostProcessing.Runtime.Attributes
{
    public sealed class MinAttribute : PropertyAttribute
    {
        public readonly float min;

        public MinAttribute(float min)
        {
            this.min = min;
        }
    }
}
