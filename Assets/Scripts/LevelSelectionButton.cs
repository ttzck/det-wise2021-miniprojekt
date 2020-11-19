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
        var text = Path.GetFileNameWithoutExtension(ScenePath);
        var time = PlayerPrefs.GetFloat(ScenePath);
        if (time != default)
        {
            text += " " + time.ToString("0.00") + " seconds";
        }
        textMesh.text = text;
    }

    public void OnClick()
    {
        SceneManager.LoadScene(ScenePath);
    }
}
