using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timeToDestroy : MonoBehaviour
{
    public int destroyRate = 6;
    public float destroyTimer = 0;

    void Update()
    {
        if(destroyTimer<destroyRate) destroyTimer+=Time.deltaTime;
        else Destroy(gameObject);
    }
}
