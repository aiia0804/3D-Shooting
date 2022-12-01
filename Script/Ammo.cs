using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ammo : MonoBehaviour
{
    [SerializeField] AmmoSlot[] ammoSlots;
    [System.Serializable]
    private class AmmoSlot
    {
        public AmmoTypes ammoTypes;
        public int ammoAmount;
    }
    public int GetAmmoAmount(AmmoTypes ammotype)
    {
        return GetAmmoType(ammotype).ammoAmount;
    }

    public void SpendAmmo(AmmoTypes ammotype)
    {
        GetAmmoType(ammotype).ammoAmount--;
    }

    private AmmoSlot GetAmmoType(AmmoTypes ammotype)
    {
        foreach (AmmoSlot slot in ammoSlots)
        {
            if (slot.ammoTypes == ammotype)
            {
                return slot;
            }
        }
        return null;
    }

    public void IncreaseAmmo(AmmoTypes ammotype, int ammount)
    {
        GetAmmoType(ammotype).ammoAmount += ammount;
    }
}
