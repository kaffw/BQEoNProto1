using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    [SerializeField] private Image totalMana;
    [SerializeField] private Image currentMana;

    public float timer = 0f;

    void Start()
    {
        totalhealthBar.fillAmount = 1;
    }

    void Update()
    {
        //currenthealthBar.fillAmount = playerHealth.currentHealth / 5;
        currenthealthBar.fillAmount = Health.currentHealth / 5;
        if (moveset.isFiring == true)
        {
            timer += Time.deltaTime;
            if (timer < 1f) currentMana.fillAmount -= (Time.deltaTime * 4f);
            else timer = 0f;
        }
        else
        {
            timer += Time.deltaTime;
            if (timer < 1f) currentMana.fillAmount += (Time.deltaTime * 4f);
            else timer = 0f;
        }
        
    }
}
