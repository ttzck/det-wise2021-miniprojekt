using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int ammunition;
    [SerializeField] private float cooldownDuration;

    private float cooldownTimestamp;
    private SpriteRenderer spriteRenderer;
    private Collider2D colliderComponent;
    private IWeaponShootingBehaviour shootingBehaviour;

    private void Start()
    {
        shootingBehaviour = GetComponent<IWeaponShootingBehaviour>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliderComponent = GetComponent<Collider2D>();
    }

    public void Fire()
    {
        if (ammunition > 0 && Time.time > cooldownTimestamp)
        {
            shootingBehaviour.Fire();
            cooldownTimestamp = Time.time + cooldownDuration;
            ammunition -- ;
        }
    }

    public void Hide() 
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = false;
        }

        if (colliderComponent != null)
        {
            colliderComponent.enabled = false;
        }
    }

    public void Show()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.enabled = true;
        }

        if (colliderComponent != null)
        {
            colliderComponent.enabled = true;
        }
    }
}
