using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool hit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().TakeDamage(damage);
            hit = true;
        }
    }
}
