using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public CapsuleCollider2D explosion;
    public float timer = 0;

    void Start()
    {
        explosion = GetComponent<CapsuleCollider2D>();
    }

    void Update()
    {
        if(timer < 5)
        {
            explosion.size = new Vector2(explosion.size.x, explosion.size.y);
            if(timer > 3)
            {
                explosion.size = new Vector2(.75f, .75f);
                explosion.offset = new Vector2(0, 0);
            }
        }
        else
        {
            Destroy(gameObject);
        }
        timer += 1 * Time.deltaTime;
    }
}
