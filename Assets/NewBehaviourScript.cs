using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Camera cam;
    [SerializeField]private float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;

    }

    // Update is called once per frame
    private void Update()
    {
        Vector2 point = cam.ScreenToWorldPoint(Input.mousePosition);
        float AngleRad = Mathf.Atan2(point.y - transform.position.y, point.x - transform.position.x);
        float AngleDeg = (Mathf.Rad2Deg) * AngleRad;
        this.transform.rotation = Quaternion.Euler(0, 0, AngleDeg);

        if (Input.GetKey(KeyCode.A))
        {

            transform.position = transform.position
                + Vector3.left * speed * Time.deltaTime;



        }

        if (Input.GetKey(KeyCode.D))
        {

            transform.position = transform.position
                + (Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.W))
        {

            transform.position = transform.position
                + Vector3.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))
        {

            transform.position = transform.position
                + Vector3.down * speed * Time.deltaTime;
        }
    }
}