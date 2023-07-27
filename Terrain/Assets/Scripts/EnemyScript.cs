using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    //private CapsuleCollider2D enemyHitBox;
    public int enemyHealth = 5;
    public bool immunity = false;

    private BoxCollider2D enemyHitBox;

    private void Start()
    {
        //enemyHitBox = GetComponent<CapsuleCollider2D>();
        enemyHitBox = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (enemyHealth == 0) Destroy(gameObject);

        if (enemyHitBox.isTrigger == true && immunity == true) //enemyHitBox.isTrigger == false
        {
            //if (!immunity)
            //{
                enemyHealth -= 1;
                //immunity = true;
                StartCoroutine(ResetImmunity());
                Debug.Log(enemyHealth);
            //}
        }
    }
    private void OnTriggerEnter2D(Collider2D enemy)
    {
        if (enemy.tag == "bullet" || enemy.tag == "projectile") Debug.Log("enemy hp -1");


        if (enemy.tag == "bullet" || enemy.tag == "projectile" && immunity == false) //enemyHitBox.isTrigger == false
        {
            Debug.Log("Hit");
            enemyHealth -= 1;
            immunity = true;
            StartCoroutine(ResetImmunity());
            Debug.Log(enemyHealth);
        }
    }
    private IEnumerator ResetImmunity()
    {
        yield return new WaitForSeconds(1f);
        immunity = false;
    }
}
