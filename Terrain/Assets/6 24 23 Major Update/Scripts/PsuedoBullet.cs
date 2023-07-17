using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PsuedoBullet : MonoBehaviour
{
    public GameObject PseudoBullet;
    private Rigidbody2D bulletrb;
    private CapsuleCollider2D bulletCapsuleCollider;
    public float fireSpeed = 20f;

    private void Start()
    {
        bulletrb = GetComponent<Rigidbody2D>();
        bulletCapsuleCollider = GetComponent<CapsuleCollider2D>();
        if (moveset.dirFire == true) bulletrb.velocity = Vector2.right * fireSpeed;
        else bulletrb.velocity = Vector2.left * fireSpeed;

        Destroy(gameObject, 20f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if  (
            other.CompareTag("Player")
            || other.CompareTag("Untagged")
            || other.CompareTag("Shield")
            || other.CompareTag("Enemy")
            )
        {
            bulletrb.velocity = Vector2.right * 0;
            bulletrb.transform.position = new Vector2(bulletrb.transform.position.x , bulletrb.transform.position.y);
            bulletCapsuleCollider.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
}
