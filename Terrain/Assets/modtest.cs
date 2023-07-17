using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;

public class modtest : MonoBehaviour
{
    public float timer = 0f;
    public float mod5 = 0f;
    public bool ifSpawn = false;
    public bool ifExit = false;
    void Start()
    {
    }

    //Update is called once per frame
    void Update()
    {
        //while 2 mins not done
        if (!ifExit)
        {
            if (timer <= 120f) // holds the condition to end
            {
                Debug.Log(ifSpawn);
                ifSpawn = false;
            }
            else
            {
                //change scene to final boss map
                Debug.Log("timer done");
                ifExit = true;
            }


            if (mod5 <= 5f)
            {
                Debug.Log("reached 5"); //will spawn a pillar whenever this condition is met *continue condition for types of pillar and additional for types of mobs
                ifSpawn = true;
            }
            else
            {
                mod5 = 0f;
                Debug.Log("mod5 reset to 0");
            }

            timer += Time.deltaTime;
            mod5 += Time.deltaTime;
        }
    }
    
}
