using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int HP = 100;
    [SerializeField] Canvas hurtingCanvas;
    void Start()
    {
        hurtingCanvas.gameObject.SetActive(false);
    }

    public void GetDamage(int damage)
    {
        HP -= damage;
        StartCoroutine(HandleHurt());
        if (HP <= 0)
        {
            print("You Dead!");
            SendMessage("HandleDeath");
        }
    }
    IEnumerator HandleHurt()
    {
        print("GetHurt");

        hurtingCanvas.gameObject.SetActive(true);
        yield return new WaitForSeconds(2);
        hurtingCanvas.gameObject.SetActive(false);
    }
}
