using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NagaHealthBar : MonoBehaviour
{
    [SerializeField] private EnemyBehaviour nagaHealth;
    [SerializeField] private Image nagatotalhealthBar;
    [SerializeField] private Image nagacurrenthealthBar;
    void Start()
    {
        nagatotalhealthBar.fillAmount = 1;
    }

    void Update()
    {
       nagacurrenthealthBar.fillAmount = nagaHealth.Hitpoints / 25f;
    }
}
