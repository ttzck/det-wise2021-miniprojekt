using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour, IDamageable
{
    [SerializeField] private GameObject gameOverSoundEffect;
    [SerializeField] private GameObject deathExplosion;

    public static Player Instance { get; private set; }

    public void Hit()
    {
        gameObject.SetActive(false);
        RestartPrompt.Instance.Show();
        Instantiate(gameOverSoundEffect);
        Instantiate(deathExplosion, transform.position, Quaternion.identity);
    }

    private void Awake()
    {
        Instance = this;
    }
}
