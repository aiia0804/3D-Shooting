using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUP : MonoBehaviour
{
    [SerializeField] int AmountIncrase = 10;
    [SerializeField] AmmoTypes ammoTypes;
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<Ammo>().IncreaseAmmo(ammoTypes, AmountIncrase);
        Destroy(gameObject);
    }
}
