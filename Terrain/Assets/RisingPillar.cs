using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class RisingPillar : MonoBehaviour
{
    public float timer = 0f;
    public int index;
    private bool run = true;
    public float speed = 5f;

    public float destroyTimer = 0f;

    public void Start()
    {
        if (PillarSpawner.yRiseCurrentPos != 0)
        {
            index = PillarSpawner.yRiseCurrentPos;
            PillarSpawner.yRiseCurrentPos++;
        }
        else
        {
            run = false;
            PillarSpawner.yRiseCurrentPos++;
        }

    }
    void Update()
    {
        if (transform.position.y + Time.deltaTime <= PillarSpawner.yRisePos[index] && run)
            transform.position = new Vector2(transform.position.x, transform.position.y + (Time.deltaTime * speed));

        //else timer += Time.deltaTime - 10f;

        if (destroyTimer <= 15f) destroyTimer += Time.deltaTime;
        else Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PillarDeleter")
        {
            Destroy(gameObject);
        }
    }
}