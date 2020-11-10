using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
    private void OnSceneGUI()
    {
        FieldOfView fov = target as FieldOfView;
        Vector3 arcStart = Quaternion.Euler(0, 0, -fov.Size * .5f) * fov.transform.right;
        Color arcColor = fov.PlayerIsInSight ? Color.red : Color.green;
        arcColor.a = .05f;

        Handles.color = arcColor;
        Handles.DrawSolidArc(fov.transform.position, fov.transform.forward, arcStart, fov.Size, 100f);
    }
}
