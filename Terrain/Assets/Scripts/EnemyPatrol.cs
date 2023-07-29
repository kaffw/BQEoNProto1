using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
//using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    public float enemyJumpForce = 10;
    [SerializeField] public float enemyHealth = 5f;

    [SerializeField] private GameObject[] patrolPoints;
    private int currentPatrolPointIndex = 0;
    [SerializeField] private float speed = 3f;

    public GameObject thisEnemy;
    public Vector2 thisEnemyPos;

    public GameObject player;
    public Vector2 Target;

    public bool wallCollided;

    public Animator enemyAnim;
    public SpriteRenderer sprite;
    public bool hit = false;

    public Vector2 direction;
    public bool isWalking = true;

    private Vector2 previousPosition;
    private float previousTime;

    public EnemyMeleeDamage isAttacking;

    private bool isAlive = true;

    public CapsuleCollider2D capsulecoll;

   // public EnemyMeleeDamage disableScript;
    private void Awake()
    {
        player = GameObject.Find("Bulan");
    }

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        enemyAnim = GetComponent<Animator>();
        capsulecoll = GetComponent<CapsuleCollider2D>();
        //disableScript = GetComponent<EnemyMeleeDamage>();

        direction = transform.position;

        previousPosition = transform.position;
        previousTime = Time.deltaTime;
        EnemyMeleeDamage isAttacking = FindObjectOfType<EnemyMeleeDamage>();
    }
    private void Update()
    {
        if (isAlive)
        {
            if (hit)
            {
                enemyAnim.SetTrigger("enemyHit");
                hit = false;
            }
            //if (enemyHealth == 0) ;// Destroy(gameObject);

            UpdateAnimation();
            if (isAttacking.Attacking == false)
            {
                direction = new Vector2(transform.position.x, transform.position.y);
                if (previousTime >= 0.15f)
                {
                    SavePosition();
                    previousPosition = transform.position;

                    previousTime = 0f;
                }
                else previousTime += Time.deltaTime;

                thisEnemyPos = new Vector2(thisEnemy.transform.position.x, thisEnemy.transform.position.y);
                Target = new Vector2(player.transform.position.x, player.transform.position.y);

                if (!EnemyRange.playerInEnemyRange)
                {
                    if (Vector2.Distance(patrolPoints[currentPatrolPointIndex].transform.position, transform.position) < .1f)
                    {
                        sprite.flipX = true;//sprite.flipX = false;
                        currentPatrolPointIndex++;
                        if (currentPatrolPointIndex >= patrolPoints.Length)
                        {
                            sprite.flipX = false;//sprite.flipX = true;
                            currentPatrolPointIndex = 0;
                        }
                    }

                    transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].transform.position, Time.deltaTime * speed);
                    isWalking = true;
                }
                /*
                else if (EnemyRange.playerInEnemyRange && Target.x < thisEnemyPos.x)
                {
                    thisEnemy.transform.position = new Vector2(transform.position.x + (-7 * Time.deltaTime), transform.position.y);
                    isWalking = true;
                    Debug.Log("moving to left");
                    //sprite.flipX = true;
                }

                else if (EnemyRange.playerInEnemyRange && Target.x > thisEnemyPos.x)
                {
                    Debug.Log("moving to right");
                    thisEnemy.transform.position = new Vector2(transform.position.x + (7 * Time.deltaTime), transform.position.y);
                    isWalking = true;
                    //sprite.flipX = false;
                }
                */
                else if (!EnemyRange.playerInEnemyRange && Target.x < thisEnemyPos.x)
                {
                    //go to patrol point A
                    transform.position = new Vector2(transform.position.x + (-7 * Time.deltaTime), transform.position.y);
                    isWalking = true;
                }

                else if ((!EnemyRange.playerInEnemyRange && Target.x > thisEnemyPos.x))
                {
                    //go to patrol point B
                    transform.position = new Vector2(transform.position.x + (7 * Time.deltaTime), transform.position.y);
                    isWalking = true;
                }

                enemyRB.mass = 3f;
                if (direction.x < previousPosition.x && !sprite.flipX) sprite.flipX = false;// sprite.flipX = true;// Debug.Log("less than previous");               && !sprite.flipX)
                else if (direction.x > previousPosition.x && sprite.flipX) sprite.flipX = true;// sprite.flipX = false; // Debug.Log("higher than previous");      && sprite.flipX)
            }
        }
    }
    public void UpdateAnimation()
    {
        if (isWalking)
        {
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8 && !wallCollided)
        {
            wallCollided = true;
            enemyRB.velocity = new Vector2(enemyRB.velocity.x, enemyJumpForce);
            //wallCollided = false;
        }
        else wallCollided = false;

        if (collision.gameObject.CompareTag("Projectile"))
        {
            enemyAnim.SetTrigger("enemyHit");
            enemyHealth--;
        }
    }
    private void SavePosition()
    {
        Vector2 oldPosition = previousPosition;
    }
    public void GroundTakeDamage()
    {
        //Debug.Log("Damage taken");
        hit = true;
        if (enemyHealth > 1)
        {
            enemyHealth--;
        }
        else
        {
            enemyHealth--;
            isAlive = false;
            StartCoroutine(DeathDelay());

        }
    }

    private IEnumerator DeathDelay()
    {
        
        enemyAnim.SetTrigger("AswangDeath");
        capsulecoll.size = new Vector2(0.0001f, 0.0001f);
        capsulecoll.offset = new Vector2(transform.position.x, -.27f);

        //disableScript.isEnabled = true;
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}