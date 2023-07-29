using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDamage: MonoBehaviour
{
    [SerializeField] private float damage;
    //public Animator enemyAnim;

    public Animator enemyAnim;
    public bool hit = false;

    public bool Attacking = false;

    private void Start()
    {
        enemyAnim.GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Debug.Log("on Contact");
        }
        /*if (collision.gameObject.CompareTag("Player"))
        {
            enemyAnim.SetTrigger("enemyAttack");
            if (moveset.isImmune == false)
            {
                StartCoroutine(DealDamage(collision));
                
                hit = true;
            }
        }
        else if (collision.gameObject.CompareTag("Terrain")) { Debug.Log("hit terrain"); }
        else { Debug.Log("hit nothing"); }
        */
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player"))
        {
            enemyAnim.SetTrigger("enemyAttack");
            if (moveset.isImmune == false)
            {
                StartCoroutine(DealDamage(collide));

                hit = true;
            }
            else if (collide.gameObject.CompareTag("Terrain")) { Debug.Log("hit terrain"); }
            else { Debug.Log("hit nothing"); }
        }
    }
    private void OnTriggerExit2D(Collider2D exitCollide)
    {
        if (exitCollide.CompareTag("Player"))
        {
            hit = false;
        }
    }
    private IEnumerator DealDamage(Collider2D collide)
    {
        Attacking = true;
        yield return new WaitForSeconds(.75f);
        if (hit) collide.gameObject.GetComponent<Health>().TakeDamage(damage);
        // Debug.Log("Exit Attack Range");
        yield return new WaitForSeconds(2.25f);
        Attacking = true;

        yield return new WaitForSeconds(0.01f);
        Attacking = false;
    }
}
