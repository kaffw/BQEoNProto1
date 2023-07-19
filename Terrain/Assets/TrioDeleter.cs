using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrioDeleter : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 15f);
    }
}
