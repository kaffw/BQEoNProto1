using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoFirePillar : MonoBehaviour
{
    public BoxCollider2D pillars;
    public float timer = 0;

    void Start()
    {
        pillars = GetComponent<BoxCollider2D>();        
    }

    void Update()
    {
        
        if (timer < 6)
        {
            if (timer < 2)
            {
                pillars.size = new Vector2(0.001f, 0.001f);
                pillars.offset = new Vector2(0, -5);
            }
            else pillars.size = new Vector2(timer / 8, 15);
        }
        /*
        if(timer < 6)
        {
            pillars.size = new Vector2(pillars.size.x, timer/4);
            if(timer > 3)
            {
                pillars.size = new Vector2(pillars.size.x, timer/(2));
            }
            pillars.offset = new Vector2(0, (timer/4)/2);
        }
        */
        else
        {
            //Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }
}
