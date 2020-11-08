using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour, ICharacterMovementInputs, ICharacterShootingInputs
{
    public Vector2 MovementDirection { get; private set; }

    public Vector2 RotationTarget { get; private set; }

    public bool IsShooting { get; private set; }

    public bool IsLaserShooting { get; private set; }

    private Camera cam;

    private static readonly (KeyCode, Vector2)[] movementInputMappings =
    {
        (KeyCode.W, Vector2.up),
        (KeyCode.A, Vector2.left),
        (KeyCode.S, Vector2.down),
        (KeyCode.D, Vector2.right)
    };

    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        UpdateRotationTarget();
        UpdateMovementDirection();
        UpdateIsShooting();
    }

    private void UpdateRotationTarget()
    {
        RotationTarget = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void UpdateMovementDirection()
    {
        Vector2 input = Vector2.zero;

        foreach ((var key, var vector) in movementInputMappings)
        {
            if (Input.GetKey(key))
            {
                input += vector;
            }
        }

        MovementDirection = input.normalized;
    }

    private void UpdateIsShooting()
    {
        IsShooting = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
        IsLaserShooting = Input.GetMouseButton(1) || Input.GetKey(KeyCode.Q);
    }
}
