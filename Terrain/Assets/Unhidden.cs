using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unhidden : MonoBehaviour
{
    public GameObject Hidden;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Hidden.SetActive(false);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Hidden.SetActive(true);
        }
    }
}
