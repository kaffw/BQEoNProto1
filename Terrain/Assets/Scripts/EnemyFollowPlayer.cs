using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    [Header("Movement parameters")]
    [SerializeField] public float speed;
    [SerializeField] public float lineOfSite;
    [SerializeField] public float distance;
    [SerializeField] public Transform player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distanceFromPlayer = Vector2.Distance(player.position, transform.position);

        if (distanceFromPlayer < lineOfSite)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.position, speed * Time.deltaTime);
        }

        if (player.position.x >= transform.position.x)
        {
            transform.position = new Vector2(transform.position.x + 3f * Time.deltaTime, transform.position.y);
            //transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (player.position.x < transform.position.x)
        {
            transform.position = new Vector2(transform.position.x  -3f * Time.deltaTime, transform.position.y);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, lineOfSite);
    }
}