using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatRanged : MonoBehaviour
{
    //public ProjectileBehaviour ProjectilePrefab;
    public Transform LaunchOffset;
    public Collision2D collision;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            //Instantiate(ProjectilePrefab, LaunchOffset.position, transform.rotation);
        }
    }
}