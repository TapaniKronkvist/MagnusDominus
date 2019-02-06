using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CameraMovement))]
public class CameraMovementEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if(GUILayout.Button("Move to player"))
        {
            CameraMovement curTar = target as CameraMovement;
            curTar.UpdatePos();
        }
    }
}
