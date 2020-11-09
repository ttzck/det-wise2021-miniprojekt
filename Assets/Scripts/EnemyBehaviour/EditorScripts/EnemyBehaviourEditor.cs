using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(EnemyBehaviour))]
public class EnemyBehaviourEditor : Editor
{
    private void OnSceneGUI()
    {
        EnemyBehaviour enemyBehaviour = target as EnemyBehaviour;

        var patrolPointPositions = enemyBehaviour.PatrolPoints
            .Select(i => i.position)
            .ToList();

        foreach (var point in patrolPointPositions)
        {
            Handles.DrawSolidDisc(point, Vector3.forward, .2f);
        }

        if (enemyBehaviour.PatrolPoints.Count() > 1)
        {
            Handles.DrawLine(patrolPointPositions.First(), patrolPointPositions.Last());

            if (patrolPointPositions.Count() > 2)
            {
                for (int i = 1; i < patrolPointPositions.Count(); i++)
                {
                    Handles.DrawLine(patrolPointPositions[i], patrolPointPositions[i - 1]);
                }
            }
        }
    }
}
