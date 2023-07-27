using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteorFalling : MonoBehaviour
{
    private Rigidbody2D meteorRB;
    [SerializeField] public float fallingSpeed;

    public GameObject host;
    public bool fallingDirection = false;
    private void Start()
    {
        meteorRB = GetComponent<Rigidbody2D>();

        host = GameObject.Find("Naga");

        if (host.transform.rotation.y >= 0)
        {
            fallingDirection = true;
        }
        if (host.transform.rotation.y < 0)
        {
            fallingDirection = false;
        }
        
    }
    void Update()
    {
        if (fallingDirection)
        {
            
            transform.position = new Vector2(meteorRB.transform.position.x - (Time.deltaTime * fallingSpeed), meteorRB.transform.position.y - (Time.deltaTime * fallingSpeed));
        }

        if (fallingDirection == false)
        {
            transform.position = new Vector2(meteorRB.transform.position.x + (Time.deltaTime * fallingSpeed), meteorRB.transform.position.y - (Time.deltaTime * fallingSpeed));
        }
    }
}
