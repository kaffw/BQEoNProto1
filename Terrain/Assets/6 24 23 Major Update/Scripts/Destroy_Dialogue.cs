using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_Dialogue : MonoBehaviour
{
    void Update()
    {
        if(Input.GetKeyDown("l"))
        {
            Dialogue.inDialogue = false;
            Dialogue.InstanceLimit = 0;
            Destroy(gameObject);
        }
    }
}
