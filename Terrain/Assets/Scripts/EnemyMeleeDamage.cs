using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeDamage: MonoBehaviour
{
    [SerializeField] private float damage;

    public Animator enemyAnim;
    public bool hit = false;

    public bool Attacking = false;
    public EnemyPatrol aliveState;
    private void Start()
    {
        enemyAnim.GetComponent<Animator>();
        aliveState = GetComponent<EnemyPatrol>();
    }

    private void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.CompareTag("Player") && aliveState.isAlive == true)
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
        hit = true;
        yield return new WaitForSeconds(.75f);
        if (hit) collide.gameObject.GetComponent<Health>().TakeDamage(damage);
        // Debug.Log("Exit Attack Range");
        yield return new WaitForSeconds(2.25f); Attacking = false;
    }
}
