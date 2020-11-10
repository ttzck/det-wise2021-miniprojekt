using UnityEngine;
using System.Collections;
public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    private ICharacterMovementInputs inputs;
    private Rigidbody2D rb2D;

    private void Start()
    {
        inputs = GetComponent<ICharacterMovementInputs>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateMovement()
    {
        rb2D.velocity = inputs.MovementDirection.normalized * movementSpeed;
    }

    private void UpdateRotation()
    {
        Vector2 rotationDirection = inputs.RotationTarget - (Vector2)transform.position;
        float AngleRad = Mathf.Atan2(rotationDirection.y, rotationDirection.x);
        rb2D.rotation = (Mathf.Rad2Deg) * AngleRad;
    }
}