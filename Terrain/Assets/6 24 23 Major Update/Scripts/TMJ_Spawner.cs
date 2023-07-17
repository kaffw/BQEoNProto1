using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMJ_Spawner : MonoBehaviour
{
    public GameObject Jump;
    public bool isCreated = false;
    public static bool is_TM_J_Exit = false;

    private void Update()
    {
        if(isCreated==true)
        {
            Instantiate(Jump, new Vector2(12,1), transform.rotation);
            isCreated  = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isCreated = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            isCreated = false;
            is_TM_J_Exit = true;
        }
    }
}
