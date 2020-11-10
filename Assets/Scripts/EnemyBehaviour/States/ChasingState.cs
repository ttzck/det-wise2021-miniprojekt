using UnityEngine;

public class ChasingState : IEnemyBehaviourState
{
    private readonly EnemyBehaviour enemyBehaviour;

    private Vector2 playerShadow;

    public ChasingState(EnemyBehaviour enemyBehaviour)
    {
        this.enemyBehaviour = enemyBehaviour;
        playerShadow = enemyBehaviour.transform.position;
    }

    public void Update()
    {
        if (PlayerIsInSight)
        {
            playerShadow = PlayerPosition;
        }

        enemyBehaviour.MovementDirection = DirectionToPlayerShadow;
        enemyBehaviour.RotationTarget = playerShadow;

        if (DistanceToPlayerShadow < EnemyBehaviour.PointReachedThreshold)
        {
            enemyBehaviour.CurrentState = new WaitingState(enemyBehaviour);
        }
    }

    private Vector2 DirectionToPlayerShadow => 
        playerShadow - (Vector2)enemyBehaviour.transform.position;

    private float DistanceToPlayerShadow =>
        Vector2.Distance(enemyBehaviour.transform.position, playerShadow);

    private bool PlayerIsInSight =>
        enemyBehaviour.FieldOfView.PlayerIsInSight;

    private Vector2 PlayerPosition => Player.Instance.transform.position;
}
