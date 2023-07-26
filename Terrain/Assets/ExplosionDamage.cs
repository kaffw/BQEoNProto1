using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionDamage : MonoBehaviour
{
    [SerializeField] private float damage;
    public bool hit = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // Use "gameObject.CompareTag" instead of "tag" directly
        {
            if (moveset.immunity == false)
            {
                // Assuming there's a "Health" script on the player with a "TakeDamage" method
                Health playerHealth = collision.gameObject.GetComponent<Health>();
                if (playerHealth != null)
                {
                    playerHealth.TakeDamage(damage);
                    hit = true;
                    moveset.immunity = true;
                }
            }
        }
        else if (collision.gameObject.CompareTag("Terrain")) // Use "gameObject.CompareTag" here as well
        {
            Debug.Log("hit terrain");
        }
        else
        {
            Debug.Log("hit nothing");
        }
    }
}
