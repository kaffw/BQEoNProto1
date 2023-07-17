using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecretEntrySM : MonoBehaviour
{
    public static int secretEntryStatus;
    
    public void Start()
    {
        secretEntryStatus = 0;
    }

    public void Update()
    {
        secretEntryStatus = EntranceToSecret.secretEntryState;

        /*if(secretEntryStatus == 0)
        {
            Debug.Log(secretEntryStatus);
        }*/
    }
}
