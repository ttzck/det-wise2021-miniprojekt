using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : IEnemyBehaviourState
{
    private int patrolPointIndex = 0;

    private EnemyBehaviour enemyBehaviour;

    public PatrollingState(EnemyBehaviour enemyBehaviour) 
    {
        this.enemyBehaviour = enemyBehaviour;
    }

    public void Update()
    {
        UpdatePatrolPointIndex();

        enemyBehaviour.MovementDirection = DirectionToCurrentPatrolPoint;
        enemyBehaviour.RotationTarget = CurrentPatrolPoint.position;

        if (enemyBehaviour.FieldOfView.PlayerIsInSight)
        {
            enemyBehaviour.CurrentState = new ChasingState(enemyBehaviour);
        }
    }

    private void UpdatePatrolPointIndex()
    {
        if (DistanceToCurrentPatrolPoint < EnemyBehaviour.PointReachedThreshold)
        {
            patrolPointIndex++;

            if (patrolPointIndex >= enemyBehaviour.PatrolPoints.Count)
            { patrolPointIndex = 0; }
        }
    }

    private Transform CurrentPatrolPoint => enemyBehaviour.PatrolPoints[patrolPointIndex];

    private float DistanceToCurrentPatrolPoint => 
        Vector2.Distance(enemyBehaviour.transform.position, CurrentPatrolPoint.position);

    private Vector2 DirectionToCurrentPatrolPoint =>
        (CurrentPatrolPoint.position - enemyBehaviour.transform.position).normalized;
}
