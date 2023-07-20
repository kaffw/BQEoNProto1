using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDeleter : MonoBehaviour
{
    public EnemyTrap hitBoxDamageDeleter;
    public GameObject objToDel;

    public CapsuleCollider2D mainHitbox;
    void Update()
    {
        if (hitBoxDamageDeleter.hit == true)
        {
            mainHitbox.offset = new Vector2(999, 999);
            objToDel.SetActive(false);
        }
    }
}
