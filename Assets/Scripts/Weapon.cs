using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public string Name;
    public GameObject projectile;
    public int ammunition;
    public float cooldownDuration;
    private float cooldownTimestamp;

    public void Fire()
    {
        if (ammunition > 0 && Time.time > cooldownTimestamp)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            cooldownTimestamp = Time.time + cooldownDuration;
            ammunition -- ;
        }
    }
}