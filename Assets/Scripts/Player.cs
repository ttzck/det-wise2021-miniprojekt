using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    public static Player Instance { get; private set; }

    public void Hit()
    {
        gameObject.SetActive(false);
        RestartPrompt.Instance.Show();
    }

    private void Awake()
    {
        Instance = this;
    }
}
