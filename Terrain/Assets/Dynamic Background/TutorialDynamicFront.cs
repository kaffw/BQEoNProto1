using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialDynamicFront : MonoBehaviour
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
            timeToMove = 0f;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CloudResetter")
        {
            //Debug.Log("reset");
            transform.position = new Vector2(transform.position.x + 150, transform.position.y);
        }
    }
}
