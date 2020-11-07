using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float cooldownDuration;

    private float cooldownTimestamp;
    private ICharacterShootingInputs inputs;

    private void Start()
    {
        inputs = GetComponent<ICharacterShootingInputs>();
    }

    private void Update()
    {
        if (inputs.IsShooting && Time.time > cooldownTimestamp)
        {
            Instantiate(projectile, transform.position, transform.rotation);
            cooldownTimestamp = Time.time + cooldownDuration;
        }
    }
}
