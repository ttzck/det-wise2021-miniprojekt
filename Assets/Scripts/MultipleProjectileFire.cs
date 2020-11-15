using UnityEngine;

public class MultipleProjectileFire : MonoBehaviour, IWeaponShootingBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float angle;
    [SerializeField] private int numberOfProjectiles;

    public void Fire()
    {
        for (int i = 0; i < numberOfProjectiles; i++)
        {

            float z =( angle / (numberOfProjectiles-1 )* i)- angle/2;
            Instantiate(projectile, transform.position, transform.rotation * Quaternion.Euler(0, 0, z));
          
        }
        }
}
