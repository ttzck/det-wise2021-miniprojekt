using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : IEnemyBehaviourState
{
    private const float pointReachedThreshold = .1f;

    private int patrolPointIndex = 0;

    private EnemyBehaviour enemyBehaviour;

    private List<Transform> patrolPoints;

    public PatrollingState(EnemyBehaviour enemyBehaviour) 
    {
        this.enemyBehaviour = enemyBehaviour;
        patrolPoints = enemyBehaviour.PatrolPoints;
    }

    public void Update()
    {
        UpdatePatrolPointIndex();

        enemyBehaviour.MovementDirection = DirectionToCurrentPatrolPoint;
        enemyBehaviour.RotationTarget = CurrentPatrolPoint.position;
    }

    private void UpdatePatrolPointIndex()
    {
        if (DistanceToCurrentPatrolPoint < pointReachedThreshold)
        {
            patrolPointIndex++;

            if (patrolPointIndex >= patrolPoints.Count)
            { patrolPointIndex = 0; }
        }
    }

    private Transform CurrentPatrolPoint => patrolPoints[patrolPointIndex];

    private float DistanceToCurrentPatrolPoint => 
        Vector2.Distance(enemyBehaviour.transform.position, CurrentPatrolPoint.position);

    private Vector2 DirectionToCurrentPatrolPoint =>
        (CurrentPatrolPoint.position - enemyBehaviour.transform.position).normalized;
}