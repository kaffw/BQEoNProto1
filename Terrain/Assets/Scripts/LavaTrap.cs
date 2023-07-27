using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool hit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            if (moveset.immunity == false)
            {
                collision.GetComponent<Health>().TakeDamage(damage);
                hit = true;
                moveset.immunity = true;
            }

        }
    }
}
