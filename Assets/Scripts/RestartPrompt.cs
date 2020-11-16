using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartPrompt : MonoBehaviour
{
    public static RestartPrompt Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
