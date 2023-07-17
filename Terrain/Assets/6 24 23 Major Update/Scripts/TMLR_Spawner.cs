using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMLR_Spawner : MonoBehaviour
{
    public GameObject Left_and_Right;
    public bool isCreated = false;
    public static bool is_TM_LR_Exit = false;

    private void Update()
    {
        if(isCreated==true)
        {
            Instantiate(Left_and_Right, new Vector2(0,0), transform.rotation);
            isCreated = false;
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
            is_TM_LR_Exit = true;
        }
    }
}
