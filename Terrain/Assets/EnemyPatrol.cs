using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.Tilemaps;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    private Rigidbody2D enemyRB;
    public float enemyJumpForce = 10;

    [SerializeField] private GameObject[] patrolPoints;
    private int currentPatrolPointIndex = 0;
    [SerializeField] private float speed = 12f;

    public GameObject thisEnemy;
    public Vector2 thisEnemyPos;

    public GameObject player;
    public Vector2 Target;

    public bool wallCollided;

    public SpriteRenderer sprite;

    public Vector2 direction;

    private Vector2 previousPosition;
    private float previousTime;

    private void Awake()
    {
        player = GameObject.Find("Bulan");
    }

    private void Start()
    {
        enemyRB = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();

        direction = transform.position;

        previousPosition = transform.position;
        previousTime = Time.deltaTime;
    }
    private void Update()
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
                sprite.flipX = false;
                currentPatrolPointIndex++;
                if (currentPatrolPointIndex >= patrolPoints.Length)
                {
                    sprite.flipX = true;
                    currentPatrolPointIndex = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPatrolPointIndex].transform.position, Time.deltaTime * speed);

        }

        else if (EnemyRange.playerInEnemyRange && Target.x < thisEnemyPos.x)
        {
            thisEnemy.transform.position = new Vector2(transform.position.x + (-7 * Time.deltaTime), transform.position.y);
            Debug.Log("moving to left");
            //sprite.flipX = true;
        }

        else if (EnemyRange.playerInEnemyRange && Target.x > thisEnemyPos.x)
        {
            Debug.Log("moving to right");
            thisEnemy.transform.position = new Vector2(transform.position.x + (7 * Time.deltaTime), transform.position.y);
            //sprite.flipX = false;
        }

        else if (!EnemyRange.playerInEnemyRange && Target.x < thisEnemyPos.x)
        {
            //go to patrol point A
            transform.position = new Vector2(transform.position.x + (-7 * Time.deltaTime), transform.position.y);
        }

        else if ((!EnemyRange.playerInEnemyRange && Target.x > thisEnemyPos.x))
        {
            //go to patrol point B
            transform.position = new Vector2(transform.position.x + (7 * Time.deltaTime), transform.position.y);
        }

        enemyRB.mass = 3f;
        if (direction.x < previousPosition.x && !sprite.flipX) sprite.flipX = true;// Debug.Log("less than previous");               && !sprite.flipX)
        else if (direction.x > previousPosition.x && sprite.flipX) sprite.flipX = false; // Debug.Log("higher than previous");      && sprite.flipX)
    }

    private void OnCollisionEnter2D(Collision2D wallCheck)
    {
        if (wallCheck.gameObject.layer == 8 && !wallCollided)
        {
            wallCollided = true;
            enemyRB.velocity = new Vector2(enemyRB.velocity.x, enemyJumpForce);
            //wallCollided = false;
        }
        else wallCollided = false;
    }
    private void SavePosition()
    {
        Vector2 oldPosition = previousPosition;
    }
}