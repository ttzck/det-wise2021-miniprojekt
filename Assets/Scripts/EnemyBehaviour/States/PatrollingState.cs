using System.Collections.Generic;
using UnityEngine;

public class PatrollingState : IEnemyBehaviourState
{
    private EnemyBehaviour enemyBehaviour;
    private int patrolPointIndex;

    public PatrollingState(EnemyBehaviour enemyBehaviour, int patrolPointIndex = 0) 
    {
        this.enemyBehaviour = enemyBehaviour;
        this.patrolPointIndex = patrolPointIndex;
    }

    public void Update()
    {
        UpdatePatrolPointIndex();

        enemyBehaviour.MovementDirection = DirectionToCurrentPatrolPoint;
        enemyBehaviour.RotationTarget = CurrentPatrolPoint.position;

        if (PlayerIsInSight)
        {
            enemyBehaviour.CurrentState = new ChasingState(enemyBehaviour);
        }
    }

    private bool PlayerIsInSight =>
        enemyBehaviour.FieldOfView.PlayerIsInSight;

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
