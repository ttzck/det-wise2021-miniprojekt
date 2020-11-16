using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(ScenePicker))]
public class LevelFinishZone : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;

    private ScenePicker scenePicker;

    private void Awake()
    {
        scenePicker = GetComponent<ScenePicker>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (layerMask.Contains(collision.gameObject.layer))
        {
            SceneManager.LoadScene(scenePicker.ScenePath);
        }
    }
}
