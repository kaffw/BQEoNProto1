using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatMelee : MonoBehaviour
{
    public float startTimeBtwAttack = 0.5f; // Adjust the time between attacks here
    public float comboResetTime = 1f; // Time before the combo resets if no attack input

    private int comboCount = 0; // Tracks the current combo count
    private bool isAttacking = false; // Flag to prevent attacking during combo

    /*[SerializeField] private float stunDamageAmount = 1f;*/
    private float attackRange;
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float damage;
    public Animator anim;
    private AttackDetails attackDetails;
    public GameObject AttackProjectile;
    public bool AttackProjectileState = false;

    private float timeBtwAttack;
    private float comboResetTimer;

    private Health health;
    private moveset moveSet;

    void Start()
    {
        DeactivateAttackProjectile();
    }

    void Update()
    {
        //Debug.Log(timeBtwAttack);
        if (isAttacking)
            return;

        /*if (timeBtwAttack > 0)
        {
            timeBtwAttack -= Time.deltaTime;
        }
        else
        {*/
            if (Input.GetKeyDown(KeyCode.J))
            {
                timeBtwAttack = startTimeBtwAttack;
                comboCount++;

                AttackProjectile.SetActive(true);
                AttackProjectileState = true;

                if (moveset.deathCounter == 0) damage *= 2;
                else damage = 1;
                //CheckAttackHitBox();

                Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
                
                for (int i = 0; i < detectedObjects.Length; i++)
                {
                    // Check for Regular Enemies with EnemyBehaviour
                    EnemyBehaviour enemyBehaviour = detectedObjects[i].GetComponent<EnemyBehaviour>();
                    if (enemyBehaviour != null)
                    {
                        enemyBehaviour.TakeHit(attackDetails.damageAmount);
                    }

                    // Check for Ground Enemies with EnemyPatrol
                    EnemyPatrol enemyPathing = detectedObjects[i].GetComponent<EnemyPatrol>();
                    if (enemyPathing != null)
                    {
                    //Debug.Log("damage dealt to enemy");
                        enemyPathing.GroundTakeDamage();
                    }

                    BreakableObject breakRocks = detectedObjects[i].GetComponent<BreakableObject>();
                    if (breakRocks != null)
                    {
                        breakRocks.BreakIt();
                    }

                    EnemyHealth mobHealth = detectedObjects[i].GetComponent<EnemyHealth>();
                    if (mobHealth != null)
                    {
                        mobHealth.GroundTakeDamage();
                    }
                }

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
            }
        //}

        // Reset combo if no attacks are performed within the comboResetTime
        if (comboCount > 0)
        {
            comboResetTimer -= Time.deltaTime;
            if (comboResetTimer <= 0f)
            {
                comboCount = 0;
            }
        }
    }
    /*
    private void CheckAttackHitBox()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);
        attackDetails.damageAmount = damage;
        attackDetails.position = transform.position;
        attackDetails.stunDamageAmount = stunDamageAmount;

        foreach (Collider2D collider in detectedObjects)
        {
            collider.transform.parent.SendMessage("Damage", attackDetails);
        }
    }

    private void Damage(AttackDetails attack)
    {
        if (!moveSet.GetDashStatus())
        {
            int direction;

            health.TakeDamage(attackDetails.damageAmount);

            /*if (attackDetails.position.x < transform.position.x)
            {
                direction = 1;
            } else
            {
                direction = -1;
            }

            moveSet.Knockback(direction);//
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
    */
    void DeactivateAttackProjectile()
    {
        AttackProjectile.SetActive(false);
    }

    IEnumerator ComboResetCoroutine()
    {
        isAttacking = true;
        yield return new WaitForSeconds(0.25f); // Delay between combo attacks //0.00625
        isAttacking = false;

        AttackProjectile.SetActive(false); // Disable the AttackProjectile after the attack
        if (comboCount >= 3)
        {
            comboCount = 0; // Reset the combo count after the third attack
        }

        comboResetTimer = comboResetTime; // Reset the combo timer
    }
}