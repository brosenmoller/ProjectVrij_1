using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MoveableObject))]
public class MoveableObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MoveableObject moveableObject = (MoveableObject)target;

        if (GUILayout.Button("Assign Current Values At Index"))
        {
            moveableObject.AssignTranformValues();
        }
    }
}

