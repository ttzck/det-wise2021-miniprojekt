using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeReference] private LevelSelectionButton levelSelectionButtonPrefab;
    [SerializeReference] private Transform leveleSelectionLayout;

    private void Start()
    {
        foreach (var scenePicker in GetComponents<ScenePicker>())
        {
            var button = Instantiate(levelSelectionButtonPrefab, leveleSelectionLayout);
            button.ScenePath = scenePicker.ScenePath;
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
