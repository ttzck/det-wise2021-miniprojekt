using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ColliderCaster))]
public class ColliderCasterEditor : Editor
{
    private void OnSceneGUI()
    {
        ColliderCaster colliderCaster = target as ColliderCaster;
        Handles.color = Color.red;
        Handles.DrawWireDisc(colliderCaster.transform.position, Vector3.forward, colliderCaster.ColliderRadius);
    }
}
