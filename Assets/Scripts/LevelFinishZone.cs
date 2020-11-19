using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ScenePicker))]
public class LevelFinishZone : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private ScenePicker scenePicker;

    private float startTime;

    private void Awake()
    {
        scenePicker = GetComponent<ScenePicker>();
    }

    private void Start()
    {
        startTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerMask.Contains(collision.gameObject.layer))
        {
            UpdateTimeRecord();

            SceneManager.LoadScene(scenePicker.ScenePath);
        }
    }

    private void UpdateTimeRecord()
    {
        var currentScene = SceneManager.GetActiveScene().path;
        var oldTime = PlayerPrefs.GetFloat(currentScene);

        if (oldTime == default || oldTime > Time.time - startTime)
        {
            PlayerPrefs.SetFloat(currentScene, Time.time - startTime);
            PlayerPrefs.Save();
        }
    }
}
