using _Code.AssignmentRelated.DropSystem._1_GeneratorSystem;
using UnityEditor;
using UnityEngine;

namespace _Code._Tools.Editor.InspectorEditors
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
