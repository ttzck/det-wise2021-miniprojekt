using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterShooting : MonoBehaviour
{
    public GameObject projectile;
    [SerializeField] private float cooldown;
    private float nextfire;
    private ICharacterShootingInputs inputs;
    // Start is called before the first frame update
    void Start()
    {
        inputs = GetComponent<ICharacterShootingInputs>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inputs.IsShooting && Time.time
            > nextfire )
        {
            Instantiate(projectile, transform.position, transform.rotation);

            nextfire = Time.time + cooldown;
        }
                
        


        
    }
}
