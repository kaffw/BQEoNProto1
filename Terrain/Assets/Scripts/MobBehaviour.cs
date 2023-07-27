using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobBehaviour : MonoBehaviour
{
    public float Hitpoints;
    public float Maxhitpoints = 5;


    void Start()
    {
        Hitpoints = Maxhitpoints;
    }

    public void MobTakeHit(float damage)
    {
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}