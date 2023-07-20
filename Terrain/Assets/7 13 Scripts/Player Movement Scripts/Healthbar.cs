using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health playerHealth;
    [SerializeField] private Image totalhealthBar;
    [SerializeField] private Image currenthealthBar;
    void Start()
    {
        totalhealthBar.fillAmount = 1;
    }

    void Update()
    {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 5;
    }
}
