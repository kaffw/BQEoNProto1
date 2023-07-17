using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_TMLR : MonoBehaviour
{
    void Update()
    {
        if(TMLR_Spawner.is_TM_LR_Exit == true)
        {
            Destroy(gameObject);
            TMLR_Spawner.is_TM_LR_Exit = false;
        }    
    }
}
