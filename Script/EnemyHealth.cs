using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int HP = 1000;


    public void GetDamage(int damage)
    {
        HP -= damage;
        BroadcastMessage("OnDamageTake");

        if (HP <= 0)
        {
            GetComponent<Animator>().SetTrigger("Dying");
            SendMessage("DetectiveDying", true);
            Destroy(gameObject, 7f);
        }
    }
}
