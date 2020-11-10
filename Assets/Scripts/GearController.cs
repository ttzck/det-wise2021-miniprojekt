using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[ExecuteAlways, RequireComponent(typeof(LineRenderer), typeof(Rigidbody2D))]
public class GearController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    private Rigidbody2D rb2d;
    private LineRenderer line;

    private int nextWaypointIndex = 1;
    private int previousWaypointIndex = 0;
    private bool forward = true;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Application.isPlaying)
        {
            Move();
        }
        else
        {
            UpdateStartingPosition();
        }
    }

    private void Move()
    {
        rb2d.velocity = SectionDirection.normalized * speed;

        float sectionLength = Vector2.Distance(
            waypoints[previousWaypointIndex].position,
            waypoints[nextWaypointIndex].position);

        float traveledDistance = Vector2.Distance(
            waypoints[previousWaypointIndex].position,
            transform.position);

        if (sectionLength < traveledDistance)
        {
            ChangeSection();
        }
    }

    private void ChangeSection()
    {
        if (nextWaypointIndex == waypoints.Count - 1 || nextWaypointIndex == 0)
        {
            FlipDirection();
        }
        else if (forward)
        {
            MoveToNextSection();
        }
        else
        {
            MoveToPreviousSection();
        }
    }

    private void FlipDirection()
    {
        forward = !forward;
        (nextWaypointIndex, previousWaypointIndex) = (previousWaypointIndex, nextWaypointIndex);
    }

    private void MoveToNextSection()
    {
        nextWaypointIndex++;
        previousWaypointIndex++;
    }

    private void MoveToPreviousSection()
    {
        nextWaypointIndex--;
        previousWaypointIndex--;
    }

    private Vector2 SectionDirection =>
        (waypoints[nextWaypointIndex].position - waypoints[previousWaypointIndex].position);

    private void UpdateStartingPosition()
    {
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
        }
        line.positionCount = waypoints.Count;
        line.SetPositions(waypoints.Select(i => i.position - Vector3.forward).ToArray());
    }
}
