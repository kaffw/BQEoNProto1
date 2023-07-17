using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 10f;
    //public Rigidbody2D rb;
    private Rigidbody2D bulletrb;

    // Update is called once per frame
    private void Start()
    {
        bulletrb = GetComponent<Rigidbody2D>();
        if (moveset.dirFire == true) bulletrb.velocity = Vector2.right * Speed;
        else bulletrb.velocity = Vector2.left * Speed;
        Destroy(gameObject, 20f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }
        Destroy(gameObject);
    }
}
