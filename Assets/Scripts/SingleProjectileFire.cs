using UnityEngine;

public class SingleProjectileFire : MonoBehaviour, IWeaponShootingBehaviour
{
    [SerializeField] private GameObject projectile;

    public void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }
}
