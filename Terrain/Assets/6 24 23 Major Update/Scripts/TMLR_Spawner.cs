using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TMLR_Spawner : MonoBehaviour
{
    public GameObject Left_and_Right;
    public GameObject Spawner;
    public Vector2 SpawnerLoc;
    public bool isCreated = false;
    public static bool is_TM_LR_Exit = false;


    private void Start()
    {
        SpawnerLoc = new Vector2(Spawner.transform.position.x, Spawner.transform.position.y);
    }
    private void Update()
    {
        if(isCreated==true)
        {
            Instantiate(Left_and_Right, SpawnerLoc, transform.rotation);
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
