using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor.SceneManagement;
#endif

[RequireComponent(typeof(Rigidbody2D))]
public class GearController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private List<Transform> waypoints = new List<Transform>();

    [Header("Line Settings")]
    [SerializeField] private GameObject lineElementPrefab;
    [SerializeField] private float lineElementSpacing;
    [SerializeField] private GameObject lineCapPrefab;
    [SerializeField] private LayerMask collisionMask;

    private Rigidbody2D rb2d;

    private int nextWaypointIndex = 1;
    private int previousWaypointIndex = 0;
    private bool forward = true;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = waypoints[0].position;
    }

    private void Update()
    {
        rb2d.velocity = CurrentSectionDirection.normalized * speed;

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

    private Vector2 CurrentSectionDirection =>
        (waypoints[nextWaypointIndex].position - waypoints[previousWaypointIndex].position);

    private float SectionLength(int x, int y) => 
        Vector2.Distance(waypoints[x].position, waypoints[y].position);

    [ContextMenu("Instantiate Line")]
    private void InstantiateLine()
    {
        GameObject line = new GameObject(gameObject.name + " Line");
        InstantiateLineElements(line.transform);
        InstantiateLineCaps(line.transform);
#if UNITY_EDITOR
        EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
#endif
    }

    private void InstantiateLineElements(Transform parent)
    {
        for (int i = 0; i < waypoints.Count - 1; i++)
        {
            int sectionElements = Mathf.FloorToInt(SectionLength(i, i + 1) / lineElementSpacing);
            for (int j = 0; j < sectionElements; j++)
            {
                Vector2 sectionElementPos = Vector2.Lerp(
                    waypoints[i].position, 
                    waypoints[i + 1].position, 
                    (float)j / sectionElements);

                Instantiate(lineElementPrefab, sectionElementPos, Quaternion.identity, parent);
            }
        }
    }

    private void InstantiateLineCaps(Transform parent)
    {
        foreach (Transform point in waypoints)
        {
            Instantiate(lineCapPrefab, point.position, Quaternion.identity, parent);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collisionMask.Contains(collision.gameObject.layer))
        {
            if (collision.TryGetComponent(out IDamageable damageable))
            {
                damageable.Hit();
            }
        }
    }
}
