using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] int WeaponPower = 100;
    [SerializeField] ParticleSystem ShootVFX;
    [SerializeField] GameObject HitVFX;
    [SerializeField] GameObject[] bloodVfx;
    [SerializeField] Ammo ammo;
    [SerializeField] float timeBetweenShoot;
    [SerializeField] AmmoTypes ammoTypes;
    [SerializeField] Text AmmoDisplay;

    [SerializeField] bool canShoot = true;


    public void SwitchWeaponPurpose()
    {
        canShoot = true;
    }

    public void AWAKE()
    {
        AmmoDisplay = GetComponent<Text>();
    }
    void Update()
    {
        AmmoDisplay.text = ammoTypes + " Ammo Left:" + ammo.GetAmmoAmount(ammoTypes).ToString();

        if (CrossPlatformInputManager.GetButtonDown("Fire1") && canShoot)
        {
            StartCoroutine(Shoot());
        }
    }
    IEnumerator Shoot()
    {
        if (ammo.GetAmmoAmount(ammoTypes) > 0)
        {
            canShoot = false;
            ProcessShootVFX();
            ProcessRycast();
            ammo.SpendAmmo(ammoTypes);
        }
        yield return new WaitForSeconds(timeBetweenShoot);
        canShoot = true;
    }

    private void ProcessShootVFX()
    {
        ShootVFX.Play();
    }

    private void ProcessRycast()
    {
        RaycastHit hit;

        if (Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            hit.transform.TryGetComponent<EnemyHealth>(out EnemyHealth target);
            ProcessHitVFX(hit, HitVFX);
            if (target == null) { return; }
            if (hit.collider == target.GetComponent<SphereCollider>())
            {
                print(hit.collider);

                var index = UnityEngine.Random.Range(0, bloodVfx.Length);
                ProcessHitVFX(hit, bloodVfx[index]);
                target.GetDamage(WeaponPower * 2);
            }

            else
            {
                target.GetDamage(WeaponPower);
            }
        }
        else { return; }
    }

    private void ProcessHitVFX(RaycastHit hit, GameObject vfx)
    {
        GameObject impact = Instantiate(vfx, hit.point, Quaternion.LookRotation(hit.normal));
        Destroy(impact, 0.2f);
    }
}
