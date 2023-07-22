using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator NagaAnim;
    public float Hitpoints;
    public float Maxhitpoints;
    public mobType type;
    public ifBoss boss;
    public bool whatType;
    void Start()
    {
        NagaAnim = GetComponent<Animator>();
        Hitpoints = Maxhitpoints;
        whatType = type.isNaga;
        if (boss)
        {
            NagaAnim = GetComponent<Animator>();
            Maxhitpoints = 200f;
        }
            
        if(type) Maxhitpoints = 5f;
    }

    public void TakeHit(float damage)
    {
        if(boss == true) NagaAnim.SetTrigger("NagaHurt");
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}