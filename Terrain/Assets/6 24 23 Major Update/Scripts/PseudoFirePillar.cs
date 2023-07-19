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
        pillars.offset = new Vector2(999, 999);
    }

    void Update()
    {
        
        if (timer < 3.15f)
        {
            if (timer < 1.6f)// && timer < 1.6f)
            {
                pillars.size = new Vector2(0.01f, 0.01f);
                pillars.offset = new Vector2(0, -5);
            }
            else if (timer > 1.6f && timer < 2.7f)
            {
                pillars.offset = new Vector2(0, 0);
                pillars.size = new Vector2(timer * (1.35f/ 10f), 1.6f); // /8
            }
            else if (timer > 2.7f)
            {
                pillars.size = new Vector2(pillars.size.x - Time.deltaTime, 1.5f);
            }
                //pillars.size = new Vector2(timer / 8, 15);
        }

        else
        {
            Destroy(gameObject);
        }
        timer += Time.deltaTime;
    }
}
