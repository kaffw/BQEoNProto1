using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth = 5f;
    public float currentHealth { get; private set; }
    private Animator anim;
    private bool dead;

    public Rigidbody2D playerRB;

    public int timer = 0;

    public static bool damaged = false;

    private void Awake()
    {
        if (moveset.oneInstance == 0) currentHealth = startingHealth;
        else
        {
            currentHealth = (5 - moveset.deathCounter);
        }
    }

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void TakeDamage(float _damage)
    {
        if (!moveset.shielded)
        {
            currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);
            if (currentHealth > 0)
            {
                anim.SetTrigger("hurt");
                Debug.Log("hurt");
                //Debug.Log(moveset.deathCounter);
            }
            else
            {
                if (!dead)
                {
                    anim.SetTrigger("die");
                    playerRB.velocity = Vector2.right * 0;
                    dead = true;
                    //Debug.Log(moveset.deathCounter);
                    Debug.Log("died");
                }
            }

            damaged = true;
        }
    }

}
