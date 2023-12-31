using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NagaPathing : MonoBehaviour
{
    //naga
    private Rigidbody2D nagaRB;
    private Animator nagaAnim;

    //player
    public GameObject Target;
    public Vector2 TargetPos;

    //direction based on player's position
    public bool faceDirection = true;

    //y
    public bool up = true, down = false;

    //movement
    public float movementTimer = 0f;
    public float movementSpeed = 3f;
    public bool left = false, right = true;

    //levitaion
    public float levitateTimer = 0f;
    public float floatSpeed = 1.25f;

    //attack pattern
    public bool attackPhase = false;
    public float attackTimer = 0f;
    public int attack;
    public float attackCastTimer=0f;
    public float attackCastInterval = 10f;
    //meteor
    public GameObject meteorSpawn;
    float castTime = 0f;
    float castInterval = 1f;
    int castQuantity = 10; // 3
    //bool endAction = false;

    //cosmic pillar
    public GameObject cosmicFirePillar;
    float spawnTime = 0f;

    //explosion
    public static bool explosions = false;
    /*
    public List<GameObject> randomExplosions = new List<GameObject>();
    public List<int> posX = new List<int>();
    public List<int> posY = new List<int>();
    public float bombTime;*/

    public EnemyBehaviour enemyBehaviour;
    public int attackLimiter = 2;
    public float HPpercentage = 150;
    private int limit = 0;
    private float attackSpeed = 5f;
    void Start()
    {
        if(BackgroundManager.isReachedEnd == false) BackgroundManager.isReachedEnd = true;
        if (MapSequenceInitializer.NagasLairEntry == false)
        {
            //SceneManager.LoadScene(19);
            MapSequenceInitializer.NagasLairEntry = true;
        }

        nagaRB = GetComponent<Rigidbody2D>();
        nagaAnim = GetComponent<Animator>();
        Target = GameObject.Find("Bulan");
        TargetPos = new Vector2(Target.transform.position.x, Target.transform.position.y);
    }

    void Update()
    {
        TargetPos = new Vector2(Target.transform.position.x, Target.transform.position.y); //Debug.Log(TargetPos);
        Debug.Log(enemyBehaviour.Hitpoints);
        ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Attack Patterns
        //atackLimiter updater
        /*if (enemyBehaviour.Hitpoints <= 150 && limit < 2)//HPpercentage && limit < 2)
        {
            if(limit < 1) attackLimiter++;
            if (enemyBehaviour.Hitpoints <= 100 && limit < 2)
            {
                attackLimiter++;
            }
            Debug.Log("25% HP reduced" + limit);
        }*/
        if (enemyBehaviour.Hitpoints <= 100 && limit < 2)
        {
            limit++;
            attackSpeed--;
            Debug.Log("25% HP reduced" + limit + attackLimiter);
            attackLimiter++;
        }
        else if (enemyBehaviour.Hitpoints <= 150 && limit < 1)
        {
            limit++;
            attackSpeed -= 2;
            Debug.Log("25% HP reduced" + limit + attackLimiter);
            attackLimiter++;
        }
        else if (enemyBehaviour.Hitpoints <= 0)
        {
            Debug.Log("Naga Died");
            SceneManager.LoadScene(32);
            Destroy(gameObject);

        }
        
        if (attackTimer <= 20f)
        {
            attackTimer += Time.deltaTime;
        }

        if (attackTimer > attackSpeed)
        {
            if (!attackPhase)
            {
                attack = UnityEngine.Random.Range(1, attackLimiter); //4
                //Debug.Log(attack);
                switch (attack)
                {
                    case 1:
                        attackPhase = true;
                        break;

                    case 2:
                        attackPhase = true;
                        break;

                    case 3:
                        attackPhase = true;
                        break;
                }
            }

            if (attackPhase && attackCastTimer < attackCastInterval)
            {
                if (attack == 1 && castQuantity != 0)
                {
                    castTime += Time.deltaTime;

                    if (castTime > castInterval)
                    {
                        if (transform.rotation.y >= 0)
                        {
                            nagaAnim.SetTrigger("NagaCasting");
                            Instantiate(meteorSpawn, new Vector2(UnityEngine.Random.Range(5, 25), 20), transform.rotation);
                        }

                        if (transform.rotation.y < 0)
                        {
                            nagaAnim.SetTrigger("NagaCasting");
                            Instantiate(meteorSpawn, new Vector2(UnityEngine.Random.Range(-30, -6), 20), transform.rotation);
                        }
                        
                        castTime = 0f;
                        castQuantity--;
                    }

                }

                //attack cast
                

                if (castQuantity == 0)
                {
                    attack = 0;
                    castQuantity = 3;
                    attackPhase = false;
                    attackTimer = 0f;
                }

                else if (attack == 2)
                {
                    nagaAnim.SetTrigger("NagaCasting");
                    spawnTime += Time.deltaTime;
                    if (spawnTime > 3f)
                    {
                        Instantiate(cosmicFirePillar, new Vector2(Target.transform.position.x + 0, 12f), transform.rotation);
                        Instantiate(cosmicFirePillar, new Vector2(Target.transform.position.x + 15, 12f), transform.rotation);
                        Instantiate(cosmicFirePillar, new Vector2(Target.transform.position.x - 15, 12f), transform.rotation);
                        attack = 0;
                        spawnTime = 0f;
                        attackPhase = false;
                        attackTimer = 0f;
                    }

                }

                else if (attack == 3)
                {
                    explosions = true;
                    attackPhase = false;
                    attackTimer = 0f;
                }

            }
        }

        Movement();
        Levitator();
        UpdateAnimation();
    }

    private void Movement()
    {
        
        if (right) //transform.position.x >= -20 && 
        {
            transform.position = new Vector2(transform.position.x - (Time.deltaTime * movementSpeed), transform.position.y);
            if (transform.position.x < -14)
            {
                right = false;
                left = true;
            }
        }

        if (left) //transform.position.x <= 20 && 
        {
            transform.position = new Vector2(transform.position.x + (Time.deltaTime * movementSpeed), transform.position.y);
            if (transform.position.x > 24)
            {
                right = true;
                left = false;
            }
        }
    }
    private void Levitator()
    {
        if (levitateTimer <= 10f)
        {
            levitateTimer += Time.deltaTime;
        }

        if (levitateTimer >= 0f && levitateTimer <= 2f)
        {
            //Naga goes up
            nagaRB.transform.position = new Vector2(nagaRB.transform.position.x, nagaRB.transform.position.y + Time.deltaTime);//+ (floatSpeed + Time.deltaTime));
        }

        if (levitateTimer >= 2.1f && levitateTimer <= 4f)
        {
            //Naga goes down
            nagaRB.transform.position = new Vector2(nagaRB.transform.position.x, nagaRB.transform.position.y - Time.deltaTime);//+ (-floatSpeed + Time.deltaTime));
        }

        if (levitateTimer > 4f) levitateTimer = 0f;

    }
    private void UpdateAnimation()
    {
        if (nagaRB.transform.position.x < Target.transform.position.x && faceDirection)
        {
            faceDirection = !faceDirection;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (nagaRB.transform.position.x > Target.transform.position.x && !faceDirection)
        {
            faceDirection = !faceDirection;
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
