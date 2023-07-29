using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroyStalactite : MonoBehaviour
{
    public GameObject parent;
    public EnemyTrap trap;

    private void Start()
    {
        trap = GetComponent<EnemyTrap>();
    }
    void Update()
    {
        if (trap.hit == true) { Destroy(parent); }
    }
}
