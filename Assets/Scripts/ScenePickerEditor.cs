﻿// from https://docs.unity3d.com/2020.1/Documentation/ScriptReference/SceneAsset.html

using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ScenePicker), true)]
public class ScenePickerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        var picker = target as ScenePicker;
        var oldScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(picker.ScenePath);

        serializedObject.Update();

        EditorGUI.BeginChangeCheck();
        var newScene = EditorGUILayout.ObjectField("scene", oldScene, typeof(SceneAsset), false) as SceneAsset;

        if (EditorGUI.EndChangeCheck())
        {
            var newPath = AssetDatabase.GetAssetPath(newScene);
            var scenePathProperty = serializedObject.FindProperty("scenePath");
            scenePathProperty.stringValue = newPath;
        }
        serializedObject.ApplyModifiedProperties();
    }
}