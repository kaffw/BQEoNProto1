using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionSpawnerRNG : MonoBehaviour
{
    public List<GameObject> ToddlerModeTouhouBombs = new List<GameObject>();

    public GameObject player;
    public Vector2 Target;
    public float timer = 0;

    public bool cast = false;

    public List<int> posX = new List<int>();
    public List<int> posY = new List<int>();
    public int index = 0;

    public int x, y;
    void Awake()
    {
        player = GameObject.Find("Bulan");
    }

    void Update()
    {
        if (NagaPathing.explosions)
        {
            cast = true;
        }

        if (timer > 0.25f && cast == true)
        {
            x = UnityEngine.Random.Range(-15, 16);
            y = UnityEngine.Random.Range(-5, 10);
            if (Target.y + y >= -7 && Target.y + y <= -2) { y += 5; }
            Instantiate(ToddlerModeTouhouBombs[index], Target + new Vector2(x, y), transform.rotation);
            index++;
            if (index == 9)
            {
                cast = false;
                posX.Clear();
                posY.Clear();
                NagaPathing.explosions = false;
                index = 0;
            }
            timer = 0f;
        }
        else timer += Time.deltaTime;
    }

    void Attack()
    {
        for (int i = 0; i < 9; i++)
        {
            int num = UnityEngine.Random.Range(-15, 16);
            posX.Add(num);

            num = UnityEngine.Random.Range(-7, 11);
            posY.Add(num);
        }

        //Instantiate(ToddlerModeTouhouBombs[0], Target, transform.rotation);
        /*
        for (int i = 0; i < 9; i++)
        {
            //Target.y = posY[i];
            if (Target.y + posY[i] >= -7 && Target.y + posY[i] <= -2)
            {
                posY[i] += 5;
            }
            Instantiate(ToddlerModeTouhouBombs[i + 1], Target + new Vector2(posX[i], posY[i]), transform.rotation);
            if (i == 8)
            {
                NagaPathing.explosions = false;
                posX.Clear();
                posY.Clear();
            }
            
        }*/
    }
}
/*
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
 */
/*
             if (timer <10) //10
            {
                Target = new Vector2(player.transform.position.x, player.transform.position.y);
            }
            else if (timer == 3) //8
            {
                for (int i = 0; i < 10; i++) Destroy(ToddlerModeTouhouBombs[i]);
            }
            else
            {
                for (int i = 0; i < 10; i++)
                {
                    int num = UnityEngine.Random.Range(-10, 11);
                    posX.Add(num);

                    num = UnityEngine.Random.Range(-10, 11);
                    posY.Add(num);
                }

                Instantiate(ToddlerModeTouhouBombs[0], Target, transform.rotation);

                StartCoroutine(SpawnExplosionDelay());

                timer = 0;
               
            }

            posX.Clear();
            posY.Clear();
            timer += Time.deltaTime;
 */