using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private float size = default;

    private ColliderCaster colliderCaster;

    public float Size => size;

    public bool PlayerIsInSight { get; private set; }

    private void Start()
    {
        colliderCaster = GetComponent<ColliderCaster>();
    }

    private void FixedUpdate()
    {
        Vector2 playerPosition = Player.Instance.transform.position;
        float angleToPlayer = Vector2.Angle(playerPosition - (Vector2)transform.position, transform.right);
        bool playerIsInFOV = Mathf.Abs(angleToPlayer) < size * .5f;
        bool viewIsObstructed = colliderCaster.Cast(playerPosition);

        PlayerIsInSight = playerIsInFOV && !viewIsObstructed && Player.Instance.gameObject.activeSelf;
    }
}
