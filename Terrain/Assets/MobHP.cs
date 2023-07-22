using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobHP : MonoBehaviour
{
    public float Hitpoints;
    public float Maxhitpoints = 5;


    void Start()
    {
        Hitpoints = Maxhitpoints;
    }

    public void TakeHit(float damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}