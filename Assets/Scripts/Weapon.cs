using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string Name;
    public GameObject projectile;
    public int ammunition;
    public float cooldownDuration;
    private float cooldownTimestamp;

    private SpriteRenderer spriteRenderer;
    private Collider2D colliderComponent;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliderComponent = GetComponent<Collider2D>();
    }

    public void Fire()
    {
        if (ammunition > 0 && Time.time > cooldownTimestamp)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            cooldownTimestamp = Time.time + cooldownDuration;
            ammunition -- ;
        }
    }

    public void Hide() 
    {
        spriteRenderer.enabled = false;
        colliderComponent.enabled = false;
    }

    public void Show()
    {
        spriteRenderer.enabled = true;
        colliderComponent.enabled = true;
    }
}