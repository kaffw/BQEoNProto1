using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPopper : MonoBehaviour
{
    [SerializeField] private GameObject soundSettings;
    private bool isOpen = false;

    void Update()
    {
        if(Input.GetKeyDown("p"))
        {
            if(isOpen)
            {
                StartCoroutine(Close());
            }
            else
            {
                StartCoroutine(Open());
            }

        }
    }

    public void Closes()
    {
        StartCoroutine(Close());
    }

    public void Opens()
    {
        StartCoroutine(Open());
    }

    private IEnumerator Close()
    {
        yield return new WaitForSeconds(0.0001f);
        soundSettings.SetActive(false);
        isOpen = false;
    }

    private IEnumerator Open()
    {
        yield return new WaitForSeconds(0.0001f);
        soundSettings.SetActive(true);
        isOpen = true;    
    }
}
