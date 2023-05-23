using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MoveableObject))]
public class MoveableObjectEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        MoveableObject moveableObject = (MoveableObject)target;

        if (GUILayout.Button("Assign Open"))
        {
            moveableObject.AssignOpenTranformValues();
        }

        if (GUILayout.Button("Assign Closed"))
        {
            moveableObject.AssignClosedTranformValues();
        }
    }
}

