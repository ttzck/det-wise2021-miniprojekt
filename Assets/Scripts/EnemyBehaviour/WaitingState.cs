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
        if (enemyBehaviour.FieldOfView.PlayerIsInSight)
        {
            enemyBehaviour.CurrentState = new ChasingState(enemyBehaviour);
        }
        enemyBehaviour.MovementDirection = randomWalkPosition - (Vector2)enemyBehaviour.transform.position;
        enemyBehaviour.RotationTarget = randomWalkPosition;
        if (Vector2.Distance(randomWalkPosition, enemyBehaviour.transform.position) < EnemyBehaviour.PointReachedThreshold)
        {
            randomWalkPosition = GetNewRandomWalkPosition();
        }
    }

    private Vector2 GetNewRandomWalkPosition()
    {
        Vector2 randomPosition = (Vector2)enemyBehaviour.transform.position 
            + Random.insideUnitCircle * randomWalkRadius;

        if (!Physics2D.Linecast(enemyBehaviour.transform.position, randomPosition, enemyBehaviour.FieldOfView.ViewObstruction))
        {
            return randomPosition;
        }
        return enemyBehaviour.transform.position;
    }
}