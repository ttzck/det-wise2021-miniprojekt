using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, ICharacterMovementInputs
{
    public const float PointReachedThreshold = .1f;

    public Vector2 MovementDirection { get; set; }

    public Vector2 RotationTarget { get; set; }

    public IEnemyBehaviourState CurrentState { get; set; }

    public List<Transform> PatrolPoints => patrolPoints;

    public FieldOfView FieldOfView { get; private set; }

    [SerializeField] private List<Transform> patrolPoints 
        = new List<Transform>();

    private void Start()
    {
        FieldOfView = GetComponent<FieldOfView>();

        MovementDirection = Vector2.zero;
        RotationTarget = transform.position + transform.right;

        if (patrolPoints.Count > 1)
        {
            CurrentState = new PatrollingState(this);
        }
        else
        {
            CurrentState = new WaitingState(this);
        }
    }

    private void Update()
    {
        CurrentState?.Update();
    }
}
