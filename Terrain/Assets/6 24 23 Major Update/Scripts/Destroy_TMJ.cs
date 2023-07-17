using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_TMJ : MonoBehaviour
{
    void Update()
    {
        if(TMJ_Spawner.is_TM_J_Exit == true)
        {
                Destroy(gameObject);
                TMJ_Spawner.is_TM_J_Exit = false;
        }
    }
}
