using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGO : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 5);
    }
}