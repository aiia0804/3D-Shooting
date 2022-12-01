using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySystem : MonoBehaviour
{
    [SerializeField] float Charge = 20;

    //For charging battery
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponentInChildren<FlashLightSystem>().Charge(Charge);
        Destroy(gameObject);

    }
}
