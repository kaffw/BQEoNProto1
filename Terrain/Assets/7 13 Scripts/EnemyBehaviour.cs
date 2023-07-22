using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator NagaAnim;
    public float Hitpoints;
    public float Maxhitpoints = 5;


    void Start()
    {
        Hitpoints = Maxhitpoints;
        NagaAnim = GetComponent<Animator>();
    }

    public void TakeHit(float damage)
    {
        NagaAnim.SetTrigger("NagaHurt");
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}