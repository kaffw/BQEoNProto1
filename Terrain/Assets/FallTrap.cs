using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallTrap : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool hit = false;

    public static bool fell = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            hit = true;
            fell = true;
            collision.GetComponent<Health>().TakeDamage(damage);

            /*moveset.isImmune = true;
            moveset.hitImmunityDuration = 3f;
            */
        }
    }
}
