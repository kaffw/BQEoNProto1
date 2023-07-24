using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] public float enemyHealth = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void GroundTakeDamage()
    {
        if (enemyHealth > 1)
        {
            enemyHealth--;
            // Insert hurt animation
        }
        else
        {
            enemyHealth--;
            Destroy(gameObject);
        }
    }
}
