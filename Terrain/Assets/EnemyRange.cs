using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public static bool playerInEnemyRange = false;

    private void OnTriggerEnter2D(Collider2D playerInRange)
    {
        if (playerInRange.tag == "Player")
        {
            Debug.Log("Player Spotted");
            playerInEnemyRange = true;
        }
    }
    private void OnTriggerExit2D(Collider2D playerInRange)
    {
        if (playerInRange.tag == "Player")
        {
            Debug.Log("Player Out of Range");
            playerInEnemyRange = false;
        }
    }
}
