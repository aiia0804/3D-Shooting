using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZOOM : MonoBehaviour
{
    [SerializeField] Camera zoomCamera;
    [SerializeField] RigidbodyFirstPersonController rigidbodyFirstPersonController;
    [SerializeField] float zoomInFOV = 30f;
    [SerializeField] float zoomOutFOV = 60f;
    [SerializeField] float zoomInMouseSensitivity = 2f;
    [SerializeField] float zoomOutMouseSensitivity = 4f;

    [Header("Gun")]
    [SerializeField] GameObject gun1;
    [SerializeField] GameObject gun2;

    bool zoomInToogle = false;

    private void OnDisable()
    {
        ZoomOut();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (zoomInToogle == false)
            {
                ZOomIn();
            }
            else
            {
                ZoomOut();
            }
        }
    }

    private void ZoomOut()
    {
        GetComponentInChildren<Weapon>().SwitchWeaponPurpose();
        zoomInToogle = false;
        zoomCamera.fieldOfView = zoomOutFOV;
        gun1.SetActive(true);
        gun2.SetActive(false);
        rigidbodyFirstPersonController.mouseLook.XSensitivity = zoomOutMouseSensitivity;
        rigidbodyFirstPersonController.mouseLook.YSensitivity = zoomOutMouseSensitivity;
    }

    private void ZOomIn()
    {
        GetComponentInChildren<Weapon>().SwitchWeaponPurpose();
        zoomInToogle = true;
        zoomCamera.fieldOfView = zoomInFOV;
        gun1.SetActive(false);
        gun2.SetActive(true);
        rigidbodyFirstPersonController.mouseLook.XSensitivity = zoomInMouseSensitivity;
        rigidbodyFirstPersonController.mouseLook.YSensitivity = zoomInMouseSensitivity;
    }
}
