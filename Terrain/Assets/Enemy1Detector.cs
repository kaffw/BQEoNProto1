using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Detector : MonoBehaviour
{
    public Enemy1Pathing playerDetector;

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {
            playerDetector.playerDetection = true;
        }
    }
    
    private void OnTriggerExit2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {
            playerDetector.playerDetection = false;
        }
    }

}
