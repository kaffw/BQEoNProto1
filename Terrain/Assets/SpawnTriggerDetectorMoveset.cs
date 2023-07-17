using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTriggerDetectorMoveset : MonoBehaviour
{
    int currentPos = 0;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            currentPos += 30;
            transform.position = new Vector2(currentPos, 0);
            PillarSpawner.ifSpawn = false;
        }
    }
}
