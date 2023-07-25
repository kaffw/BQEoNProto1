using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_TMM : MonoBehaviour
{
    void Update()
    {
        if (TMM_Spawner.is_TM_M_Exit == true)
        {
            Destroy(gameObject);
            TMM_Spawner.is_TM_M_Exit = false;
        }
    }
}
