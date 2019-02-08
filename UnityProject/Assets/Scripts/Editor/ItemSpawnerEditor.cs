using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
[CustomEditor(typeof(ItemSpawner))]
public class ItemSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Test spawn item"))
        {
            (target as ItemSpawner).SpawnItem((target as ItemSpawner).testPickup);
        }
    }
}
