using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Play, Options, Credit, Exit;
    public GameObject playText, optionxText, creditText, exitText; //
    public GameObject Options_Menu, Main_Menu, Credit_Menu;


    public Color PlayColor, OptionsColor, ExitColor;
    public Color color;

    private Image PlayImage, OptionsImage, CreditImage, ExitImage;
    private Image playShrink, optionsShrink, creditShrink, exitShrink; //

    /*
    public GameObject soundButtonText, controlButtonText, creditButtonText; ///
    private Image soundButton, controlButton, creditButton; ///
    */
    private void Awake()
    {
        PlayImage = Play.GetComponent<Image>();
        OptionsImage = Options.GetComponent<Image>();
        CreditImage = Credit.GetComponent<Image>();
        ExitImage = Exit.GetComponent<Image>();

        //  newly added
        playShrink = playText.GetComponent<Image>(); //playShrink.GetComponent<Image>();
        optionsShrink = optionxText.GetComponent<Image>(); //optionsShrink.GetComponent<Image>();
        creditShrink = creditText.GetComponent<Image>(); //creditShrink.GetComponent<Image>();
        exitShrink = exitText.GetComponent<Image>(); //exitShrink.GetComponent<Image>();

        /*
        // settings update ///
        soundButton = soundButtonText.GetComponent<Image>();
        controlButton = controlButtonText.GetComponent<Image>();
        creditButton = creditButtonText.GetComponent<Image>();
        */

    }
    public void PlayGame()
    {
        StartCoroutine(PlayWait());
    }
    public void OptionGame()
    {
        StartCoroutine(OptionWait());
    }
    public void CreditGame()
    {
        StartCoroutine(CreditWait());
    }
    public void QuitGame()
    {
        StartCoroutine(ExitWait());
    }

    /*
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
    */
    private IEnumerator PlayWait()
    {
        //PlayImage.color = new Color(255,255,0,255);
        playShrink.color = new Color(255, 255, 0, 255);
        playShrink.rectTransform.sizeDelta = new Vector2(190, 90);

        PlayImage.rectTransform.sizeDelta = new Vector2(190, 90);

        yield return new WaitForSeconds(0.25f);
        playShrink.color = new Color(255, 255, 255, 255);
        playShrink.rectTransform.sizeDelta = new Vector2(200, 100);

        PlayImage.rectTransform.sizeDelta = new Vector2(200, 100);

        //PlayImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(22);
    }
    private IEnumerator OptionWait()
    {
        //OptionsImage.color = new Color(255, 255, 0, 255);
        optionsShrink.color = new Color(255, 255, 0, 255);
        optionsShrink.rectTransform.sizeDelta = new Vector2(115, 50);

        OptionsImage.rectTransform.sizeDelta = new Vector2(115, 50);

        yield return new WaitForSeconds(0.25f);
        optionsShrink.color = new Color(255, 255, 255, 255);
        optionsShrink.rectTransform.sizeDelta = new Vector2(125, 50);

        OptionsImage.rectTransform.sizeDelta = new Vector2(125, 50);
        
        //OptionsImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Options_Menu.SetActive(true);
        Main_Menu.SetActive(false);
        Debug.Log("Entered Option Menu Successfully");
    }
    private IEnumerator CreditWait()
    {
        //CreditImage.color = new Color(255, 255, 0, 255);
        creditShrink.color = new Color(255, 255, 0, 255);
        creditShrink.rectTransform.sizeDelta = new Vector2(140, 40);

        CreditImage.rectTransform.sizeDelta = new Vector2(140, 40);

        yield return new WaitForSeconds(0.25f);
        creditShrink.color = new Color(255, 255, 255, 255);
        creditShrink.rectTransform.sizeDelta = new Vector2(150, 50);

        CreditImage.rectTransform.sizeDelta = new Vector2(150, 50);
        //CreditImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Debug.Log("Entered Credit");
        Credit_Menu.SetActive(true);
        Main_Menu.SetActive(false);
    }
    private IEnumerator ExitWait()
    {
        exitShrink.color = new Color(255, 255, 0, 255);
        exitShrink.rectTransform.sizeDelta = new Vector2(90, 40);
        //ExitImage.color = new Color(255, 255, 0, 255);
        ExitImage.rectTransform.sizeDelta = new Vector2(90, 40);

        yield return new WaitForSeconds(0.25f);
        exitShrink.color = new Color(255, 255, 255, 255);
        exitShrink.rectTransform.sizeDelta = new Vector2(100, 50);

        ExitImage.rectTransform.sizeDelta = new Vector2(100, 50);
        //ExitImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Debug.Log("Quit!");
        Application.Quit();
    }

    /*
    private IEnumerator SoundWait()
    {
        soundButton.color = new Color(255, 255, 0, 255);
        soundButton.rectTransform.sizeDelta = new Vector2(190, 90);

        //PlayImage.rectTransform.sizeDelta = new Vector2(190, 90); //button frame 

        yield return new WaitForSeconds(0.25f);
        playShrink.color = new Color(255, 255, 255, 255);
        playShrink.rectTransform.sizeDelta = new Vector2(200, 100);

        //PlayImage.rectTransform.sizeDelta = new Vector2(200, 100); //button frame

        Debug.Log("Sound tab active");
        //active state
        //soundButton.SetActive(true);

        yield return new WaitForSeconds(0.25f);
    }
    private IEnumerator ControlWait()
    {
        yield return new WaitForSeconds(0);
    }
    private IEnumerator CreditOptWait()
    {
        yield return new WaitForSeconds(0);
    }
    */
}