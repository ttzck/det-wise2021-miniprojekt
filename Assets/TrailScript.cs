using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailScript : MonoBehaviour
{
    private ParticleSystem particle;
    private Transform target;

    private void Awake()
    {
        particle = GetComponent<ParticleSystem>();
    }

    private void Start()
    {
        target = transform.parent;
        transform.parent = null;
    }

    private void Update()
    {
        if (target == null || !target.gameObject.activeSelf)
        {
            particle.Stop();
        }
        else
        {
            transform.position = target.position;
        }
    }
}
