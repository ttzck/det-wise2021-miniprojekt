using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private Weapon startingWeapon;

    private ICharacterShootingInputs inputs;

    public Weapon Weapon { get; private set; }

    private void Start()
    {
        inputs = GetComponent<ICharacterShootingInputs>();
        if(startingWeapon!= null)
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

    public void SetWeapon(Weapon weapon)
    {
        if (weapon != null)
        {
            weapon.transform.parent = transform;
            weapon.transform.localPosition = Vector3.zero;
            weapon.transform.localRotation = Quaternion.identity;
            weapon.Hide();

            Weapon = weapon;
        }
    }
}
