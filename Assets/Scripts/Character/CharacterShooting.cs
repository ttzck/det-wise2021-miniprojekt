using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private Weapon startingWeapon;

    private ICharacterShootingInputs inputs;

    public Weapon Weapon { get; private set; }

    private void Start()
    {
        inputs = GetComponent<ICharacterShootingInputs>();
        if (startingWeapon != null)
        {
            SetWeapon(Instantiate(startingWeapon));
        }
    }


    private void Update()
    {
        if (inputs.IsShooting)
        {
            Weapon?.Fire();
        }
    }

    public void SetWeapon(Weapon newWeapon)
    {
        if (Weapon != null)
        {
            Weapon.transform.parent = null;
            Weapon.Show();
        }

        Weapon = newWeapon;

        if (Weapon != null)
        {
            Weapon.transform.parent = transform;
            Weapon.transform.localPosition = Vector3.zero;
            Weapon.transform.localRotation = Quaternion.identity;
            Weapon.Hide();
        }
    }
}
