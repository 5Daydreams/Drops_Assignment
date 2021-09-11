using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(ClearAllChildren))]
public class ClearAllChildrenEditor : Editor
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
