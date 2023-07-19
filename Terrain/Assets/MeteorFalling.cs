using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorFalling : MonoBehaviour
{
    private Rigidbody2D meteorRB;
    [SerializeField] public float fallingSpeed;

    private void Start()
    {
        meteorRB = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        transform.position = new Vector2(meteorRB.transform.position.x - (Time.deltaTime * fallingSpeed), meteorRB.transform.position.y - (Time.deltaTime * fallingSpeed ));
    }
}
