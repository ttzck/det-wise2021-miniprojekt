using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
   
    private ICharacterShootingInputs inputs;

    private void Start()
    {
        inputs = GetComponent<ICharacterShootingInputs>();
    }

    private void Update()
    {
        if (inputs.IsShooting)
        {
            weapon.Fire();
            
        }
    }
}
