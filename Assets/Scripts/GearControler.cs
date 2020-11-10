using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GearControler: MonoBehaviour 
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    Rigidbody2D rb2d;
    private int Next = 1, Prev = 0;
    private bool forward = true;
    [SerializeField]private float speed = 10f;
    private LineRenderer line;
    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        transform.position = waypoints[0].position;
        line.positionCount = waypoints.Count;
        line.SetPositions(waypoints.Select(i => i.position).ToArray());
    }

    // Update is called once per frame
    void Update()
    {
        
        rb2d.velocity = (waypoints[Next].position - waypoints[Prev].position).normalized * speed;

        float distance  =  Vector2.Distance(waypoints[Prev].position, transform.position);
        float distance2 = Vector2.Distance(waypoints[Prev].position, waypoints[Next].position);
        if (distance2 < distance)
        {
            if (Next == waypoints.Count-1 || Next == 0)
            {
                forward = !forward;
                (Next, Prev) = (Prev, Next);
                     
            }
           else if (forward)
            {

                Next++;
                Prev++;
            }
            else
            {
                Next--;
                Prev--;
            }

        }

        
    }
}
