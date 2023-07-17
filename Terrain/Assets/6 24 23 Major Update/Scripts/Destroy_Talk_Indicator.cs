using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Talk_Indicator : MonoBehaviour
{

    void Update()
    {
        if (Dialogue.TalkIndicatorIfDestroy == true)
        {
            Destroy(gameObject);
        }
    }
}