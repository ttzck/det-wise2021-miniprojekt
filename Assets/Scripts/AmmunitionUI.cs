using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmunitionUI : MonoBehaviour
{
    private const int MaxIcons= 50;

    [SerializeField] private GameObject ammunitionIcon;

    private CharacterShooting characterShooting;
    private GameObject[] icons = new GameObject[MaxIcons];
    private int iconsIndex;

    private void Start()
    {
        characterShooting = Player.Instance.GetComponent<CharacterShooting>();
    }


    private void Update()
    {
        int ammuntition = characterShooting.Weapon != null ? characterShooting.Weapon.Ammunition : 0;

        if (ammuntition > iconsIndex && iconsIndex < icons.Length)
        {
            icons[iconsIndex] = Instantiate(ammunitionIcon, transform);
            iconsIndex++;
        }
        else if (ammuntition < iconsIndex)
        {
            Destroy(icons[iconsIndex-1]);
            iconsIndex--;
        }
    }
}
