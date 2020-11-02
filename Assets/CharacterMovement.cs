using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10f;

    private ICharacterMovementInputs inputs;

    private void Start()
    {
        inputs = GetComponent<ICharacterMovementInputs>();
        if (inputs == null)
        {
            Debug.LogError($"Missing {nameof(ICharacterMovementInputs)} Component", gameObject);
        }
    }

    private void Update()
    {
        UpdateMovement();
        UpdateRotation();
    }

    private void UpdateMovement()
    {
        transform.position += (Vector3)inputs.MovementDirection.normalized
                    * movementSpeed * Time.deltaTime;
    }

    private void UpdateRotation()
    {
        Vector2 point = inputs.RotationTarget;
        float AngleRad = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x);
        float AngleDeg = (Mathf.Rad2Deg) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);
    }
}