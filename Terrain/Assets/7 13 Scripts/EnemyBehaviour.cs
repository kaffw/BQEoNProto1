using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public Animator NagaAnim;
    public float Hitpoints;
    [SerializeField] public float Maxhitpoints;

    void Start()
    {
        Hitpoints = Maxhitpoints;
        NagaAnim = GetComponent<Animator>();
        Maxhitpoints = 5f;
    }

    public void TakeHit(float damage)
    {
        NagaAnim.SetTrigger("NagaHurt");
        Hitpoints -= damage;
        if (Hitpoints <= 0)
        {
            Destroy(gameObject);
        }
    }
}