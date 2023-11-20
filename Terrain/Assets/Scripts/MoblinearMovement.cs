using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoblinearMovement : MonoBehaviour
{
    public GameObject mob;
    public Rigidbody2D mobRB;
    public float moveSpeed = 8f;
    void Start()
    {
        mobRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        mobRB.transform.position = new Vector2(transform.position.x - (Time.deltaTime * moveSpeed), transform.position.y);
    }
}
