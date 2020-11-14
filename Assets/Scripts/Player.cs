using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour , IDamageable
{
    public static Player Instance { get; private set; }

    public void Hit()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    private void Awake()
    {
        Instance = this;
    }
}
