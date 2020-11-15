using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Projectile : MonoBehaviour, INotify
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask collisionMask;

    private Rigidbody2D rb2D;

    public event Action Event;

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
            Event?.Invoke();
        }
    }
}
