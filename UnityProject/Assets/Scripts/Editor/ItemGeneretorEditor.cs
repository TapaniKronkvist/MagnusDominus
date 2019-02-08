using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ItemGenerator))]
public class ItemGeneretorEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Spawn test items")) (target as ItemGenerator).TestSpawnItems();
        if (GUILayout.Button("Redo items")) (target as ItemGenerator).RedoItems();
    }
}
