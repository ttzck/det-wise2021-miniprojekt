using UnityEngine;

public class FastFire : MonoBehaviour, IWeaponShootingBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float angle;

    public void Fire()
    {
        float z = Random.Range(-angle/2, angle/2) ;
        Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 0, z));
    }
}