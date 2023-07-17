using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMelee : MonoBehaviour
{
    private float timeBtwAttack;
    private float startTimeBtwAttack;


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
        MeleeAttack();
    }

    void MeleeAttack()
    {
        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown("g"))
            {
                AttackProjectile.SetActive(true);
                AttackProjectileState = true;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                AttackDetails[0] = damage;
                AttackDetails[1] = transform.position.x;
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().TakeHit(damage);

                }
                anim.SetTrigger("melee attack");

                Invoke("DeactivateAttackProjectile", 0.25f);
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
        //AttackProjectileState = false;
        //Debug.Log(AttackProjectileState);
    }
}
