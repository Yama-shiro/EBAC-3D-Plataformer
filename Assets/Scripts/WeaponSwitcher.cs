using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WeaponSwitcher : MonoBehaviour
{
    [Header("Armas (prefabs ou referências já na cena)")]
    public GameObject weapon1;
    public GameObject weapon2;

    private GameObject currentWeapon;

    void Start()
    {
        // Ativa a primeira arma no início
        EquipWeapon(weapon1);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EquipWeapon(weapon1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EquipWeapon(weapon2);
        }
    }

    void EquipWeapon(GameObject weapon)
    {
        if (currentWeapon != null)
        {
            currentWeapon.SetActive(false); // desativa a arma anterior
        }

        currentWeapon = weapon;
        currentWeapon.SetActive(true); // ativa a nova arma
    }
}

