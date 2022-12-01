using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour
{
    [SerializeField] int CurrentWeapon = 0;


    void Start()
    {
        SetWeaponActive();
    }

    private void SetWeaponActive()
    {
        int weaponIndex = 0;

        foreach (Transform weapon in transform)
        {
            if (weaponIndex == CurrentWeapon)
            {
                weapon.gameObject.SetActive(true);
                BroadcastMessage("SwitchWeaponPurpose");
            }
            else
            {
                weapon.gameObject.SetActive(false);
            }
            weaponIndex++;
        }
    }

    void Update()
    {
        int previousWeapon = CurrentWeapon;

        ProcessKeyInput();
        ProcessScrollInput();
        if (previousWeapon != CurrentWeapon)
        {
            SetWeaponActive();
        }
    }



    private void ProcessKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentWeapon = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentWeapon = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentWeapon = 2;
        }
    }

    private void ProcessScrollInput()
    {


        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (CurrentWeapon <= 0)
            {
                CurrentWeapon = transform.childCount - 1;
            }
            else
            {
                CurrentWeapon--;
            }
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (CurrentWeapon >= transform.childCount - 1)
            {
                CurrentWeapon = 0;
            }
            else
            {
                CurrentWeapon++;
            }
        }
    }
}
