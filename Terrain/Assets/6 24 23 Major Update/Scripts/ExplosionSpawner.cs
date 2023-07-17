using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawner : MonoBehaviour
{
    public List<GameObject> ToddlerModeTouhouBombs = new List<GameObject>();

    public GameObject player;
    public Vector2 Target;
    public float timer = 0;

    void Awake()
    {
        player = GameObject.Find("Character");
    }

    void Update()
    {

        if(timer < 10)
        {
            Target = new Vector2(player.transform.position.x, player.transform.position.y);
        }
        else if(timer == 8)
        {
            for (int i = 0; i < 5; i++) Destroy(ToddlerModeTouhouBombs[i]);
        }
        else
        {
            Instantiate(ToddlerModeTouhouBombs[0], Target, transform.rotation);
            Instantiate(ToddlerModeTouhouBombs[1], Target + new Vector2(5, 5), transform.rotation);
            Instantiate(ToddlerModeTouhouBombs[2], Target + new Vector2(-5, -5), transform.rotation);
            Instantiate(ToddlerModeTouhouBombs[3], Target + new Vector2(-5, 5), transform.rotation);
            Instantiate(ToddlerModeTouhouBombs[4], Target + new Vector2(5, -5), transform.rotation);

            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
