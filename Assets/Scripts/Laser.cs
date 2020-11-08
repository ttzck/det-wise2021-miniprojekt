﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private LayerMask collisionMask;
    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
