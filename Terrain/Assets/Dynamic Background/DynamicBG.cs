using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicBG : MonoBehaviour
{
    public GameObject dynamicBg;
    public Rigidbody2D dynamicBGRB;
    public float timeToMove;

    [SerializeField] private float scrollSpeed = 0.5f;
    void Start()
    {
        dynamicBGRB = GetComponent<Rigidbody2D>();
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