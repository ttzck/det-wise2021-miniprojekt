using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask collisionMask;
    [SerializeField, Range(0,1)] private float screenShakeTrauma;
    [SerializeField] private GameObject explosionPrefab;

    private Rigidbody2D rb2D;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisionMask.Contains(collision.gameObject.layer))
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.Hit();
            }
            Destroy(gameObject);
            ScreenShake.Instance.AddTrauma(screenShakeTrauma);
            Instantiate(explosionPrefab, transform.position, transform.rotation);
        }
    }
}
