using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Unhidden : MonoBehaviour
{
    public GameObject Hidden;
    public Tilemap hiderTilemap;
    private Color originalColor; // Store the original color to revert it on OnTriggerExit2D

    private void Start()
    {
        originalColor = hiderTilemap.color; // Store the original color
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hidden.SetActive(false);
            hiderTilemap.color = new Color(1f, 1f, 1f, 0.5f); // Change alpha to 0.5 (50% transparency)
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Hidden.SetActive(true);
            hiderTilemap.color = new Color(255f, 255f, 255f, 255f); // Revert to the original color
        }
    }
}
