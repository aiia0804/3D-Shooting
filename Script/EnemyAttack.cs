using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform Target;
    [SerializeField] int Damage = 50;

    public void AttackEvent()
    {
        if (Target == null) { return; }
        print("attack");
        Target.GetComponent<PlayerHealth>().GetDamage(Damage);
    }
}
