using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateSM : MonoBehaviour
{
    public static int pressurePlateStatus;

    public void Start()
    {
        pressurePlateStatus = 0;
    }

    public void Update()
    {
        pressurePlateStatus = PressurePlateDetector.pressurePlateState;
    }
}
