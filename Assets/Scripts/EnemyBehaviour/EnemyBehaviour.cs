using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, ICharacterMovementInputs,ICharacterShootingInputs
{
    public const float PointReachedThreshold = .1f;

    public Vector2 MovementDirection { get; set; }

    public Vector2 RotationTarget { get; set; }

    public IEnemyBehaviourState CurrentState { get; set; }

    public List<Transform> PatrolPoints => patrolPoints;

    public FieldOfView FieldOfView { get; private set; }

    public ColliderCaster ColliderCaster { get; private set; }

    public bool IsShooting => true;

    [SerializeField] private List<Transform> patrolPoints 
        = new List<Transform>();

    private void Start()
    {
        FieldOfView = GetComponent<FieldOfView>();
        ColliderCaster = GetComponent<ColliderCaster>();

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
