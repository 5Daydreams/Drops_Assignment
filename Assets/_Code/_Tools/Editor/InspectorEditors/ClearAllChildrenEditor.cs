using UnityEditor;
using UnityEngine;

namespace _Code._Tools.Editor.InspectorEditors
{
    [CustomEditor(typeof(ClearAllChildren))]
    public class ClearAllChildrenEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("Clear all children game objects"))
            {
                ((ClearAllChildren)target).ClearAllChildrenObjects();
            }
        }
    }
}
