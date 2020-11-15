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
        if (Input.GetMouseButtonDown(1) || Input.GetKeyDown(KeyCode.Q))
        {
            PickUpWeapon();
        }
    }

    private void PickUpWeapon()
    {
        Collider2D pickedUpObject = Physics2D.OverlapCircle(transform.position, weaponPickUpRange, weaponLayerMask);
        Weapon pickedUpWeapon = pickedUpObject != null ? pickedUpObject.GetComponent<Weapon>() : null;

        characterShooting.SetWeapon(pickedUpWeapon);
    }
}
