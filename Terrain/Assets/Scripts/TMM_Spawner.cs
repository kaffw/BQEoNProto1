using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMM_Spawner : MonoBehaviour
{
    public GameObject Melee;
    public bool isCreated = false;
    public static bool is_TM_M_Exit = false;

    private void Update()
    {
        if (isCreated == true)
        {
            Instantiate(Melee, new Vector2(22, 1), transform.rotation);
            isCreated = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCreated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isCreated = false;
            is_TM_M_Exit = true;
        }
    }
}
