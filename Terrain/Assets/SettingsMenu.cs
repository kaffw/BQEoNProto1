using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public GameObject soundButtonText, controlButtonText, creditButtonText; ///
    private Image soundButton;//, controlButton, creditButton; ///

    private void Awake()
    {
        soundButton = soundButtonText.GetComponent<Image>();
        //controlButton = controlButtonText.GetComponent<Image>();
        //creditButton = creditButtonText.GetComponent<Image>();
    }
    public void SoundButtonUpdate()
    {
        StartCoroutine(SoundWait());
    }
    public void ControlButtonUpdate()
    {
        StartCoroutine(ControlWait());
    }
    public void CreditButtonUpdate()
    {
        StartCoroutine(CreditOptWait());
    }

    private IEnumerator SoundWait()
    {
        soundButton.color = new Color(255, 255, 0, 255);
        soundButton.rectTransform.sizeDelta = new Vector2(190, 90);

        //PlayImage.rectTransform.sizeDelta = new Vector2(190, 90); //button frame 

        yield return new WaitForSeconds(0.25f);
        soundButton.color = new Color(255, 255, 255, 255);
        soundButton.rectTransform.sizeDelta = new Vector2(200, 100);

        //PlayImage.rectTransform.sizeDelta = new Vector2(200, 100); //button frame

        Debug.Log("Sound tab active");
        //active state
        //soundButton.SetActive(true);

        yield return new WaitForSeconds(0.25f);
    }
    private IEnumerator ControlWait()
    {
        soundButton.color = new Color(255, 255, 0, 255);
        soundButton.rectTransform.sizeDelta = new Vector2(190, 90);

        //PlayImage.rectTransform.sizeDelta = new Vector2(190, 90); //button frame 

        yield return new WaitForSeconds(0.25f);
        soundButton.color = new Color(255, 255, 255, 255);
        soundButton.rectTransform.sizeDelta = new Vector2(200, 100);

        //PlayImage.rectTransform.sizeDelta = new Vector2(200, 100); //button frame

        Debug.Log("Sound tab active");
        //active state
        //soundButton.SetActive(true);

        yield return new WaitForSeconds(0.25f);
        /*
        Debug.Log("Control tab active");
        yield return new WaitForSeconds(0);
        */
    }
    private IEnumerator CreditOptWait()
    {
        Debug.Log("Credit tab active");
        yield return new WaitForSeconds(0);
    }
}
