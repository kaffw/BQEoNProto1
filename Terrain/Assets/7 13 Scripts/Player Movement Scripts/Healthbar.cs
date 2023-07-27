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

    [SerializeField] private List<Image> moonPhases = new List<Image>();
    public int moonIndex = 0;
    public float timer = 0f;
    public int HPinInt;
    void Start()
    {
        totalhealthBar.fillAmount = 1;
    }

    void Update()
    {
        //currenthealthBar.fillAmount = playerHealth.currentHealth / 5;
        currenthealthBar.fillAmount = Health.currentHealth / 5;
        HPinInt = (int)Health.currentHealth;
switch (HPinInt)
{
    case 1:
        currenthealthBar.color = new Color(1f, 1f, 1f, 0.2f); // Opacity: 0.2 (out of 1)
        moonPhases[0].enabled = true;
        moonPhases[1].enabled = false;
        moonPhases[2].enabled = false;
        moonPhases[3].enabled = false;
        moonPhases[4].enabled = false;
        break;

    case 2:
        currenthealthBar.color = new Color(1f, 1f, 1f, 0.4f); // Opacity: 0.39 (out of 1)
        moonPhases[0].enabled = false;
        moonPhases[1].enabled = true;
        moonPhases[2].enabled = false;
        moonPhases[3].enabled = false;
        moonPhases[4].enabled = false;
        break;

    case 3:
        currenthealthBar.color = new Color(1f, 1f, 1f, 0.6f); // Opacity: 0.59 (out of 1)
        moonPhases[0].enabled = false;
        moonPhases[1].enabled = false;
        moonPhases[2].enabled = true;
        moonPhases[3].enabled = false;
        moonPhases[4].enabled = false;
        break;

    case 4:
        currenthealthBar.color = new Color(1f, 1f, 1f, 0.8f); // Opacity: 0.98 (out of 1)
        moonPhases[0].enabled = false;
        moonPhases[1].enabled = false;
        moonPhases[2].enabled = false;
        moonPhases[3].enabled = true;
        moonPhases[4].enabled = false;
        break;

    case 5:
        currenthealthBar.color = new Color(1f, 1f, 1f, 1f); // Opacity: 1 (fully opaque)
        moonPhases[4].enabled = true;
        moonPhases[0].enabled = false;
        moonPhases[1].enabled = false;
        moonPhases[2].enabled = false;
        moonPhases[3].enabled = false;
        break;
}

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
