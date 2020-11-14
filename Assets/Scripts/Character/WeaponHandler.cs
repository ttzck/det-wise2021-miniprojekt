using UnityEngine;

[RequireComponent(typeof(CharacterShooting))]
public class WeaponHandler : MonoBehaviour
{
    [SerializeField] private float weaponPickUpRange;
    [SerializeField] private LayerMask weaponLayerMask;

    private CharacterShooting characterShooting;

    private void Start()
    {
        characterShooting = GetComponent<CharacterShooting>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PickUpWeapon();
        }
    }

    private void PickUpWeapon()
    {
        Collider2D pickedUp = Physics2D.OverlapCircle(transform.position, weaponPickUpRange, weaponLayerMask);

        if (characterShooting.Weapon != null)
        {
            characterShooting.Weapon.transform.parent = null;
            characterShooting.Weapon.Show();
        }

        if (pickedUp != null)
        {
            Weapon pickedUpWeapon = pickedUp.GetComponent<Weapon>();
            characterShooting.SetWeapon(pickedUpWeapon);
        }
    }
}
