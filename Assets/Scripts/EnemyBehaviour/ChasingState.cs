using UnityEngine;

public class ChasingState : IEnemyBehaviourState
{
    private readonly EnemyBehaviour enemyBehaviour;

    private Vector2 lastSeenPlayerPosition;

    public ChasingState(EnemyBehaviour enemyBehaviour)
    {
        this.enemyBehaviour = enemyBehaviour;
        lastSeenPlayerPosition = enemyBehaviour.transform.position;
    }

    public void Update()
    {
        if (enemyBehaviour.FieldOfView.PlayerIsInSight)
        {
            lastSeenPlayerPosition = Player.Instance.transform.position;
        }

        enemyBehaviour.MovementDirection = DirectionToLastSeenPlayerPosition;
        enemyBehaviour.RotationTarget = lastSeenPlayerPosition;

        if (DistanceToLastSeenPlayerPosition < EnemyBehaviour.PointReachedThreshold)
        {
            enemyBehaviour.CurrentState = new WaitingState(enemyBehaviour);
        }
    }

    private Vector2 DirectionToLastSeenPlayerPosition => 
        lastSeenPlayerPosition - (Vector2)enemyBehaviour.transform.position;

    private float DistanceToLastSeenPlayerPosition =>
        Vector2.Distance(enemyBehaviour.transform.position, lastSeenPlayerPosition);
}
