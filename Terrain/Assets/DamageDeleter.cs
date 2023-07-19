using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeleter : MonoBehaviour
{
    public EnemyTrap hitBoxDamageDeleter;
    public GameObject objToDel;

    void Update()
    {
        if (hitBoxDamageDeleter.hit == true)
        {
            objToDel.SetActive(false);
        }
    }
}
