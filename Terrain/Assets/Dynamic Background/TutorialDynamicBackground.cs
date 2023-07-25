using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDynamicBackground : MonoBehaviour
{
    public GameObject dynamicBack;
    public Rigidbody2D dynamicBackRB;
    public float timeToMove;

    [SerializeField] private float scrollSpeed = 1f;
    void Start()
    {
        dynamicBackRB = GetComponent<Rigidbody2D>();
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
            timeToMove = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CloudResetter")
        {
            Debug.Log("reset");
            transform.position = new Vector2(transform.position.x + 150, transform.position.y);
        }
    }
}