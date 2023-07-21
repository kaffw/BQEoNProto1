using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawnerRNG : MonoBehaviour
{
    public List<GameObject> ToddlerModeTouhouBombs = new List<GameObject>();

    public GameObject player;
    public Vector2 Target;
    public float timer = 0;

    public List<int> posX = new List<int>();
    public List<int> posY = new List<int>();

    void Awake()
    {
        player = GameObject.Find("Bulan");
    }

    void Update()
    {
        if (NagaPathing.explosions)
        {
            if (timer <5) //10
            {
                Target = new Vector2(player.transform.position.x, player.transform.position.y);
            }
            else if (timer == 3) //8
            {
                for (int i = 0; i < 5; i++) Destroy(ToddlerModeTouhouBombs[i]);
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    int num = UnityEngine.Random.Range(-10, 11);
                    posX.Add(num);

                    num = UnityEngine.Random.Range(-10, 11);
                    posY.Add(num);
                }

                Instantiate(ToddlerModeTouhouBombs[0], Target, transform.rotation);

                for (int i = 0; i < 4; i++)
                {
                    Instantiate(ToddlerModeTouhouBombs[i + 1], Target + new Vector2(posX[i], posY[i]), transform.rotation);
                    if (i == 3) NagaPathing.explosions = false;
                }

                timer = 0;
               
            }

            posX.Clear();
            posY.Clear();
            timer += Time.deltaTime;
        }
    }
}