using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMelee : MonoBehaviour
{
    private float timeBtwAttack;
    private float startTimeBtwAttack;

    private int comboCount = 0; // Tracks the current combo count
    private bool isAttacking = false; // Flag to prevent attacking during combo

    private float attackRange;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float damage;
    public Animator anim;
    private float[] AttackDetails = new float[2];
    public GameObject AttackProjectile;
    public bool AttackProjectileState = false;

    void Start()
    {
        DeactivateAttackProjectile();
    }

    void Update()
    {
        if (timeBtwAttack <= 0)
        {
            if (!isAttacking && Input.GetKeyDown("g"))
            {
                //isAttacking = true; // Set attacking flag to prevent further attacks until combo is complete
                comboCount++;

                /*
                AttackProjectile.SetActive(true);
                AttackProjectileState = true;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                AttackDetails[0] = damage;
                AttackDetails[1] = transform.position.x;
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().TakeHit(damage);
                }
                */

                // Trigger the appropriate animation based on the combo count
                switch (comboCount)
                {
                    case 1:
                        anim.SetTrigger("melee attack 1");
                                        AttackProjectile.SetActive(true);
                AttackProjectileState = true;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                AttackDetails[0] = damage;
                AttackDetails[1] = transform.position.x;
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().TakeHit(damage);
                }
                        isAttacking = true;
                        break;
                    case 2:
                        anim.SetTrigger("melee attack 2");
                                        AttackProjectile.SetActive(true);
                AttackProjectileState = true;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                AttackDetails[0] = damage;
                AttackDetails[1] = transform.position.x;
                /*
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().TakeHit(damage);
                }
                */
                        isAttacking = true;
                        break;
                    case 3:
                        anim.SetTrigger("melee attack 3");
                                        AttackProjectile.SetActive(true);
                AttackProjectileState = true;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                AttackDetails[0] = damage;
                AttackDetails[1] = transform.position.x;
                /*
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().TakeHit(damage);
                }*/
                        isAttacking = true;
                        break;
                }

                Invoke("EndCombo", 0.25f); // Call EndCombo after a short delay to allow the next attack
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    void DeactivateAttackProjectile()
    {
        AttackProjectile.SetActive(false);
    }

    void EndCombo()
    {
        isAttacking = false;
        if (comboCount >= 3) // Reset the combo count after the third attack
        {
            comboCount = 0;
        }
    }
}
