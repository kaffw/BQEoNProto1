using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NagaHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth = 25f;
    public float nagaCurrentHealth { get; private set; }
    private bool dead = false;

    private void Awake()
    {
        nagaCurrentHealth = startingHealth;
    }
    public void TakeDamage(float _damage)
    {

        nagaCurrentHealth = Mathf.Clamp(nagaCurrentHealth - 1, 0, startingHealth);//_damage, 0, startingHealth);
        if (nagaCurrentHealth > 0)
        {
            //anim.SetTrigger("hurt");
        }
        else
        {
            if (!dead)
            {
                //anim.SetTrigger("die");
                dead = true;
            }
        }
    }
}
