using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateKeySM : MonoBehaviour
{
    public static Vector2 pressurePlateKeyPos;
    public static int instance = 0;

    void Awake()
    {
        if(instance != 0)
        {
            transform.position = pressurePlateKeyPos;
        }
    }

    void Start()
    {
        if(instance == 0)
        {
            transform.position = new Vector2(47, 46);
            instance++;
        }
    }

    void Update()
    {
        pressurePlateKeyPos = transform.position;        
    }
}
