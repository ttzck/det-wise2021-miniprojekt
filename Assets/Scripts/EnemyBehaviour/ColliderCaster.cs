using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ColliderCaster : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private float colliderRadius;

    public float ColliderRadius => colliderRadius;

    public bool Cast(Vector2 point)
    {
        float distance = Vector2.Distance(transform.position, point);
        Vector2 direction = point - (Vector2)transform.position;
        return Physics2D.CircleCast(transform.position, 
            colliderRadius, direction, distance, layerMask);
    }
}
