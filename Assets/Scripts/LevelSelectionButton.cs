using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;

public class LevelSelectionButton : MonoBehaviour
{
    public string ScenePath { get; set; }

    private void Start()
    {
        var textMesh = GetComponentInChildren<TextMeshProUGUI>();
        textMesh.text = Path.GetFileNameWithoutExtension(ScenePath);
    }

    public void OnClick()
    {
        SceneManager.LoadScene(ScenePath);
    }
}
