using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateDetector : MonoBehaviour
{
    public static int pressurePlateState = 0;

    private void Awake()
    {
        if(PressurePlateSM.pressurePlateStatus == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PressurePlateKey"))
        {
            PressurePlateSM.pressurePlateStatus = 1;
            pressurePlateState = 1;
            Destroy(gameObject);
        }
    }
}