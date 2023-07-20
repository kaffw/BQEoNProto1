using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;

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

    //levitaion
    public float levitateTimer = 0f;
    public float floatSpeed = 1.25f;

    //attack pattern
    public bool attackPhase = false;
    public float attackTimer = 0f;
    public int attack;
    //meteor
    public GameObject meteorSpawn;
    float castTime = 0f;
    float castInterval = 1f;
    int castQuantity = 3;
    //bool endAction = false;

    //cosmic pillar
    public GameObject cosmicFirePillar;
    float spawnTime = 0f;
    //explosion
    public List<GameObject> randomExplosions = new List<GameObject>();


    void Start()
    {
        nagaRB = GetComponent<Rigidbody2D>();
        nagaAnim = GetComponent<Animator>();
        Target = GameObject.Find("Bulan");
        TargetPos = new Vector2(Target.transform.position.x, Target.transform.position.y);
    }

    void Update()
    {
        TargetPos = new Vector2(Target.transform.position.x, Target.transform.position.y); //Debug.Log(TargetPos);
                                                                                           
///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Attack Patterns
        if (attackTimer <= 20f)
        {
            attackTimer += Time.deltaTime;
        }

        if (attackTimer > 5f)
        {
            if (!attackPhase)
            {
                attack = UnityEngine.Random.Range(1, 3);

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

            if (attackPhase)
            {
                if (attack == 1 && castQuantity != 0)
                {
                    castTime += Time.deltaTime;

                    if (castTime > castInterval)
                    {
                        Instantiate(meteorSpawn, new Vector2(UnityEngine.Random.Range(5, 36), 20), transform.rotation);
                        castTime = 0f;
                        castQuantity--;
                    }

                }
                if (castQuantity == 0)
                {

                    attack = 0;
                    castQuantity = 3;
                    attackPhase = false;
                    attackTimer = 0f;
                }

                else if (attack == 2)
                {
                    spawnTime += Time.deltaTime;
                    if (spawnTime > 3f)
                    {
                        Instantiate(cosmicFirePillar, new Vector2(Target.transform.position.x + 0, 5.5f), transform.rotation);
                        Instantiate(cosmicFirePillar, new Vector2(Target.transform.position.x + 15, 5.5f), transform.rotation);
                        Instantiate(cosmicFirePillar, new Vector2(Target.transform.position.x - 15, 5.5f), transform.rotation);
                        attack = 0;
                        spawnTime = 0f;
                        attackPhase = false;
                    }

                }

                else if (attack == 3) { }

            }

        }
        

        Levitator();
        UpdateAnimation();
    }
    /*
    private void AttackPattern()
    {
        if (attackTimer <= 10f)
        {
            attackTimer += Time.deltaTime;
        }

        if (attackTimer >= 5f)
        {
            int attack = UnityEngine.Random.Range(1, 2);

            switch (attack)
            {
                case 1:
                    CastMeteor();
                break;

                case 2:
                    CastCosmicPillar();
                break;

                case 3:
                    CastRandomExplosions();
                break;
            }
        }
        if (attackTimer > 9f) attackTimer = 0f;
        //create timer
        //insert attack patterns

    }
    */

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
    /*
    private void CastMeteor()
    {
        AttackPhase = true;
        float castTime = 0f;
        float castInterval = 1f;
        int castQuantity = 0;
        bool endAction = false;

        while (castQuantity < 3)
        {

            if (castTime > castInterval)
            {
                Instantiate(meteorSpawn, new Vector2(UnityEngine.Random.Range(5, 36), 20), transform.rotation);
                castTime = 0f;
                castQuantity++;
            }
            else castTime += Time.deltaTime;

        }
        if (castQuantity == 2)
        {
            attackTimer = 0f;
            castQuantity = 0;
            AttackPhase = false;
        }
    }

    private void CastCosmicPillar() { }

    private void CastRandomExplosions() { }
    */
}
/*
        AttackPhase = true;
        float castTime = 0f;
        float castInterval = 1f;
        int castQuantity = 0;
        bool endAction = false;

        while (castQuantity < 3)
        {

            if (castTime > castInterval)
            {
                Instantiate(meteorSpawn, new Vector2(UnityEngine.Random.Range(5, 36), 20), transform.rotation);
                castTime = 0f;
                castQuantity++;
            }
            else castTime += Time.deltaTime;

        }
        if (castQuantity == 2)
        {
            attackTimer = 0f;
            castQuantity = 0;
            AttackPhase = false;
        }
 */
