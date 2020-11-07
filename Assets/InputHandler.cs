using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour, ICharacterMovementInputs,ICharacterShootingInputs
{
    public Vector2 MovementDirection { get; private set; }
    public Vector2 RotationTarget { get; private set; }

    public bool IsShooting { get; private set; }
    private Camera cam;

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

        if (Input.GetKey(KeyCode.A))
        {
            input += Vector2.left;
        }

        if (Input.GetKey(KeyCode.D))
        {
            input += Vector2.right;
        }

        if (Input.GetKey(KeyCode.W))
        {
            input += Vector2.up;
        }

        if (Input.GetKey(KeyCode.S))
        {
            input += Vector2.down;
        }

        MovementDirection = input.normalized;
    }

    private void UpdateIsShooting()
    {
        IsShooting = Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space);
    }
}
