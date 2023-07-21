using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMelee : MonoBehaviour
{
    public float startTimeBtwAttack = 0.5f; // Adjust the time between attacks here
    public float comboResetTime = 1f; // Time before the combo resets if no attack input

    private int comboCountTemp = 0; //last attack
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

    private float timeBtwAttack;
    private float comboResetTimer;

    private float AttackTimer;
    
    void Start()
    {
        DeactivateAttackProjectile();
    }

    void Update()
    {
        if (comboCount > 2) comboCount = 0;
        if (AttackTimer > 1f)
        {
            AttackTimer = 0f;
            comboCount = 0;
        }
        else AttackTimer += Time.deltaTime;

        if (isAttacking)
            return;

        if (timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.G) && comboCount < 3)
            {
                comboCount++;
                if (comboCount > 2) comboCount = 0;

                if (AttackTimer < 1f) comboCount++;
                else comboCount = 0;

                AttackProjectile.SetActive(true);
                AttackProjectileState = true;

                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                AttackDetails[0] = damage;
                AttackDetails[1] = transform.position.x;
                for (int i = 0; i < enemiesToDamage.Length; i++)
                {
                    enemiesToDamage[i].GetComponent<EnemyBehaviour>().TakeHit(damage);
                }

                if (comboCount == 1)
                {
                    anim.SetTrigger("melee attack 1");
                    StartCoroutine(ComboSequence());
                }

                if (comboCount == 2)
                {
                    anim.SetTrigger("melee attack 2");
                    StartCoroutine(ComboSequence());
                }

                if (comboCount == 3)
                {
                    anim.SetTrigger("melee attack 3");
                    StartCoroutine(ComboSequence());

                }


                /*
                // Trigger the appropriate animation based on the combo count
                switch (comboCount)
                {
                    case 1:
                        anim.SetTrigger("melee attack 1");
                        break;
                    case 2:
                        anim.SetTrigger("melee attack 2");
                        break;
                    case 3:
                        anim.SetTrigger("melee attack 3");
                        break;
                }
                
                StartCoroutine(ComboResetCoroutine()); // Start the coroutine to reset the combo
                */
            }
        }
        
        // Reset combo if no attacks are performed within the comboResetTime
        /*if (comboCount > 0)
        {
            comboResetTimer -= Time.deltaTime;
            if (comboResetTimer <= 0f)
            {
                comboCount = 0;
            }
        }
        */
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
    /*
    IEnumerator ComboResetCoroutine()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.25f); // Delay between combo attacks
        isAttacking = false;

        AttackProjectile.SetActive(false); // Disable the AttackProjectile after the attack

        if (comboCount >= 3)
        {
            comboCount = 0; // Reset the combo count after the third attack
        }

        comboResetTimer = comboResetTime; // Reset the combo timer
    }
    */
    private IEnumerator ComboSequence()
    {
        yield return new WaitForSeconds(0.25f);
        AttackProjectile.SetActive(false);
    }
}