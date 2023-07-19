using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosions : MonoBehaviour
{
    public CapsuleCollider2D explosion;
    private Animator explosionAnim;
    public float timer = 0;

    void Start()
    {
        explosion = GetComponent<CapsuleCollider2D>();
        explosionAnim = GetComponent<Animator>();
    }

    void Update()
    {
        if(timer < 4.5f)
        {
            explosion.offset = new Vector2(999, 999);
            explosionAnim.SetBool("Indicator", true);
            explosion.size = new Vector2(explosion.size.x, explosion.size.y);
            if(timer > 3)
            {
                explosionAnim.SetBool("Indicator", false);
                explosionAnim.SetTrigger("Explosion");
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
