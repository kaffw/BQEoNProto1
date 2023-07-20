using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 12.5f;
    //public Rigidbody2D rb;
    private Rigidbody2D bulletrb;
    public Animator bulletAnim;

    private bool freezeMotion = false;

    // Update is called once per frame
    private void Start()
    {
        bulletAnim = GetComponent<Animator>();
        bulletrb = GetComponent<Rigidbody2D>();
        if (moveset.dirFire == true) bulletrb.velocity = Vector2.right * Speed;
        else bulletrb.velocity = Vector2.left * Speed;
        Destroy(gameObject, 15f);
    }

    private void Update()
    {
        if (freezeMotion) bulletrb.velocity *= 0f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        freezeMotion = true;
        var enemy = collision.collider.GetComponent<EnemyBehaviour>();
        if (enemy)
        {
            enemy.TakeHit(1);
        }

        bulletAnim.SetTrigger("ProjectileBurst");

        Destroy(gameObject, 1.15f);
    }
}
