using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private int ammunition;
    [SerializeField] private float cooldownDuration;
    [SerializeField] private bool infiniteAmmunition;
    [SerializeField] private GameObject soundEffect;

    private float cooldownTimestamp;
    private SpriteRenderer spriteRenderer;
    private Collider2D colliderComponent;
    private IWeaponShootingBehaviour shootingBehaviour;

    public int Ammunition => ammunition;

    private void Awake()
    {
        shootingBehaviour = GetComponent<IWeaponShootingBehaviour>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colliderComponent = GetComponent<Collider2D>();
    }

    public void Fire()
    {
        if ((ammunition > 0 || infiniteAmmunition) && Time.time > cooldownTimestamp)
        {
            shootingBehaviour.Fire();
            cooldownTimestamp = Time.time + cooldownDuration;
            ammunition -- ;
            Instantiate(soundEffect);
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
