using UnityEditor;
using UnityEngine;

namespace _Tools.Editor
{
    [CustomEditor(typeof(ItemGenerator))]
    public class ItemGeneratorEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Drop Random Item"))
            {
                ((ItemGenerator)target).DropRandomItem();
            }
        }
    }
}
