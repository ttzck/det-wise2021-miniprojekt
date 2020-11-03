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
        if (inputs == null)
        {
            Debug.LogError($"Missing {nameof(ICharacterMovementInputs)} Component", gameObject);
        }
    }

    private void FixedUpdate()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateMovement()
    {
        rb2D.velocity = (inputs.MovementDirection.normalized
                    * movementSpeed * Time.fixedDeltaTime);
    }

    private void UpdateRotation()
    {
        Vector2 point = inputs.RotationTarget;
        float AngleRad = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x);
        float AngleDeg = (Mathf.Rad2Deg) * AngleRad;
        rb2D.rotation = AngleDeg;
    }
}