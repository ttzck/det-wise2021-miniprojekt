using UnityEngine;

public class WaitingState : IEnemyBehaviourState
{
    private const float randomWalkRadius= 5f;

    private readonly EnemyBehaviour enemyBehaviour;

    private Vector2 randomWalkPosition;

    public WaitingState(EnemyBehaviour enemyBehaviour)
    {
        this.enemyBehaviour = enemyBehaviour;
        randomWalkPosition = GetNewRandomWalkPosition();
    }

    public void Update()
    {
        enemyBehaviour.MovementDirection = DirectionToRandomWalkPositon;
        enemyBehaviour.RotationTarget = randomWalkPosition;
        UpdateCurrentState();

        if (DistanceToRandomWalkPosition < EnemyBehaviour.PointReachedThreshold)
        {
            randomWalkPosition = GetNewRandomWalkPosition();
        }
    }

    private void UpdateCurrentState()
    {
        if (enemyBehaviour.FieldOfView.PlayerIsInSight)
        {
            enemyBehaviour.CurrentState = new ChasingState(enemyBehaviour);
        }
        else
        {
            LookForReachablePatrolPoints();
        }
    }

    private void LookForReachablePatrolPoints()
    {
        for (int i = 0; i < enemyBehaviour.PatrolPoints.Count; i++)
        {
            bool patrolPointIsReachable = !Physics2D.Linecast(
                enemyBehaviour.transform.position,
                enemyBehaviour.PatrolPoints[i].position,
                enemyBehaviour.FieldOfView.ViewObstruction);

            if (patrolPointIsReachable)
            {
                enemyBehaviour.CurrentState = new PatrollingState(enemyBehaviour, i);
                return;
            }
        }
    }

    private Vector2 GetNewRandomWalkPosition()
    {
        Vector2 randomPosition = (Vector2)enemyBehaviour.transform.position 
            + Random.insideUnitCircle * randomWalkRadius;

        bool isReachable = !Physics2D.Linecast(
            enemyBehaviour.transform.position, 
            randomPosition, 
            enemyBehaviour.FieldOfView.ViewObstruction);

        if (isReachable)
        {
            return randomPosition;
        }

        return enemyBehaviour.transform.position;
    }

    private float DistanceToRandomWalkPosition =>
        Vector2.Distance(randomWalkPosition, enemyBehaviour.transform.position);

    private Vector2 DirectionToRandomWalkPositon =>
        randomWalkPosition - (Vector2)enemyBehaviour.transform.position;
}