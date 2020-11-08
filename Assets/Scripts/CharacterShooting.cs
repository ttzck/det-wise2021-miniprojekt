using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private float weaponPickUpRange;
    [SerializeField] private LayerMask weaponLayerMask;
   
    private ICharacterShootingInputs inputs;
    private Weapon weapon;

    private void Start()
    {
        inputs = GetComponent<ICharacterShootingInputs>();
    }

    private void Update()
    {
        if (inputs.IsShooting)
        {
            weapon?.Fire();
        }

        if (Input.GetMouseButtonDown(1))
        {
            PickUpWeapon();
        }
    }

    private void PickUpWeapon()
    {
        Collider2D pickedUp = Physics2D.OverlapCircle(transform.position, weaponPickUpRange, weaponLayerMask);

        if (weapon != null)
        {
            weapon.transform.parent = null;
            weapon.Show();
        }

        if (pickedUp != null)
        {
            weapon = pickedUp.GetComponent<Weapon>();
            weapon.transform.parent = transform;
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
            weapon.Hide();
        }
    }
}
