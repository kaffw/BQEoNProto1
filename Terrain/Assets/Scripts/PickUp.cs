using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject pickedUp;
    private Health plusLife;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Health.currentHealth < 5)
            {
                MapSequenceInitializer.savedCurrentHealth++;
                Health.currentHealth += 1f;
                moveset.deathCounter--;
            }
            Destroy(pickedUp);
        }
    }
}