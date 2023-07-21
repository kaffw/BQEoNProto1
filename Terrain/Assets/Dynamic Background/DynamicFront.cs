using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicFront : MonoBehaviour
{
    public GameObject dynamicFront;
    public Rigidbody2D dynamicFrontRB;
    public float timeToMove;

    [SerializeField] private float scrollSpeed = 2f;
    void Start()
    {
        dynamicFrontRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (timeToMove <= 20f)
        {
            transform.position = new Vector2(transform.position.x - Time.deltaTime * scrollSpeed, 0);
            timeToMove += Time.deltaTime;
        }

        else
        {
            Debug.Log("background has been moved");
            transform.position = new Vector2((128 + transform.position.x) - (Time.deltaTime * scrollSpeed), 0);
            timeToMove = 0f;
        }
    }
}
