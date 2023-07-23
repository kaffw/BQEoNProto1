using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Pathing : MonoBehaviour
{
    public GameObject GroundEnemy;
    public Rigidbody2D Enemy1RB;
    public Animator Enemy1Anim;
    
    [SerializeField] public float enemyHealth = 5f;
    
    [SerializeField] public float enemyMoveSpeed = 2f; // walking speed
    [SerializeField] public float chaseRunSpeed = 3f; // chasing speed = enemyMoveSpeed * chaseRunSpeed
    public bool playerDetection = false; //changes movement behaviour (chasing player then attacking)
    public bool isAttacking = false; //one attack at a time
    
    public GameObject target;
    public Vector2 targetPos;
    
    [SerializeField] public GameObject PatrolPointA, PatrolPointB;
    public bool currentDirection = false; //true = left, false = right;
    [SerializeField] public GameObject Aggro;

    private void Start()
    {
        Enemy1RB = GetComponent<Rigidbody2D>();   
        Enemy1Anim = GetComponent<Animator>();
        target = GameObject.Find("Bulan");
    }

    private void Update()
    {
        Aggro.transform.position = new Vector2(50, -2);
        targetPos = new Vector2(target.transform.position.x, target.transform.position.y);
        
        HorizontalMove();
        //UpdateAnimation();
    }
    
    private void HorizontalMove()
    {
        if(playerDetection == false)
        {
            //if(GroundEnemy.transform.position.x >= PatrolPointA.transform.position.x && currentDirection == false) //&& playerDetection == false && isAttacking == false; //or compile all ifs and put inside if(isAttacking == false)

            if(currentDirection == false) //&& playerDetection == false && isAttacking == false; //or compile all ifs and put inside if(isAttacking == false)
            {
                transform.position = new Vector2(transform.position.x - (enemyMoveSpeed * Time.deltaTime), transform.position.y);
                if(transform.position.x < PatrolPointA.transform.position.x)
                {
                    currentDirection = true;
                }
            } // from right to left
            // code from right going to left
            else if(currentDirection == true)
            //else if(GroundEnemy.transform.position.x <= PatrolPointB.transform.position.x && currentDirection == true) //&&playerDetection == false && isAttacking == false; 
            {
                transform.position = new Vector2(transform.position.x + (enemyMoveSpeed * Time.deltaTime), transform.position.y);
                if(transform.position.x > PatrolPointB.transform.position.x)
                {
                    currentDirection = false;
                }

            } // from left to right
            // code from left going to right

        }
        
        if(playerDetection == true)// isAttacking == false)
        {
            if(isAttacking == true)
            {
                isAttacking = false;
                StartCoroutine(Attacking());
            }
            else
            {
                if(transform.position.x > target.transform.position.x)//targetPos)
                {
                    transform.position = new Vector2(transform.position.x - ((enemyMoveSpeed * chaseRunSpeed) * Time.deltaTime), transform.position.y);
                    //code chase player from right to left
                }
                if(transform.position.x < target.transform.position.x)//targetPos)
                {
                    transform.position = new Vector2(transform.position.x + ((enemyMoveSpeed* chaseRunSpeed) * Time.deltaTime), transform.position.y);
                    //code chase player from left to right
                }                
            }
        }
        //player inside attack range... pause for x sec then attack.
    }
    
    private void UpdateAnimation()
    {
        //run
        
        //hurt
        
        //attack
    }

    /*private OnTriggerEnter2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {
            playerDetection = true;
        }
    }*/
    
    /*private OnTriggerExit2D(Collider2D collide)
    {
        if(collide.CompareTag("Player"))
        {
            playerDetection = false;
        }
    }*/
/*
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Projectile"))
        {
            if (enemyHealth > 1)
            {
                enemyHealth--;
                // Insert hurt animation
            }
            else
            {
                enemyHealth--;
                Destroy(gameObject);
            }
        }
    }*/

    public void GroundTakeDamage()
    {
        if (enemyHealth > 1)
        {
            enemyHealth--;
            // Insert hurt animation
        }
        else
        {
            enemyHealth--;
            Destroy(gameObject);
        }
    }

    private IEnumerator Attacking()
    {
        
        yield return new WaitForSeconds(.1f); //delay before attacking
        //code for attacking
        yield return new WaitForSeconds(.1f);
        isAttacking = false; //resetting attack limiter
    }

}
