using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour, ICharacterMovementInputs
{
    public Vector2 MovementDirection { get; set; }

    public Vector2 RotationTarget { get; set; }

    public IEnemyBehaviourState CurrentState { get; set; }

    public List<Transform> PatrolPoints => patrolPoints;


    [SerializeField] private List<Transform> patrolPoints = default;


    private void Start()
    {
        MovementDirection = transform.position;
        RotationTarget = transform.position;

        if (patrolPoints.Count > 0)
        {
            CurrentState = new PatrollingState(this);
        }
    }

    private void Update()
    {
        CurrentState?.Update();
    }
}
