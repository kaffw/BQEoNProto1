using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public GameObject soundButton, controlButton, creditButton;
    public GameObject soundObj, controlObj, creditObj;
    private Image showSound, showControl, showCredit;

    void Awake()
    {
        showSound = soundObj.GetComponent<Image>();
        showControl = controlObj.GetComponent<Image>();
        showCredit = creditObj.GetComponent<Image>();
    }

    private void Start()
    {
        soundButton.SetActive(true);
        controlButton.SetActive(true);
        creditButton.SetActive(true);

        soundObj.SetActive(true);
        controlObj.SetActive(false);
        creditObj.SetActive(false);
    }

    public void DispSound()
    {
        StartCoroutine(DispSoundWait());
    }

    public void DispControl()
    {
        StartCoroutine(DispControlWait());
    }

    public void DispCredit()
    {
        StartCoroutine(DispCreditWait());
    }

    private IEnumerator DispSoundWait()
    {
        yield return new WaitForSeconds(0.25f);
        soundObj.SetActive(true);
        controlObj.SetActive(false);
        creditObj.SetActive(false);
        yield return new WaitForSeconds(0.25f);
    }

    private IEnumerator DispControlWait()
    {
        yield return new WaitForSeconds(0.25f);
        soundObj.SetActive(false);
        controlObj.SetActive(true);
        creditObj.SetActive(false);
        yield return new WaitForSeconds(0.25f);
    }

    private IEnumerator DispCreditWait()
    {
        yield return new WaitForSeconds(0.25f);
        soundObj.SetActive(false);
        controlObj.SetActive(false);
        creditObj.SetActive(true);
        yield return new WaitForSeconds(0.25f);
    }

}
