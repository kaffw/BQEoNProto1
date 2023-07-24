using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject Play, Options, Credit, Exit;
    public GameObject Options_Menu, Main_Menu, Credit_Menu;
    public Color PlayColor, OptionsColor, ExitColor;
    public Color color;

    private Image PlayImage, OptionsImage, CreditImage, ExitImage;


    private void Awake()
    {
        PlayImage = Play.GetComponent<Image>();
        OptionsImage = Options.GetComponent<Image>();
        CreditImage = Credit.GetComponent<Image>();
        ExitImage = Exit.GetComponent<Image>();
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

    private IEnumerator PlayWait()
    {
        PlayImage.color = new Color(255,255,0,255);
        PlayImage.rectTransform.sizeDelta = new Vector2(190, 90);

        yield return new WaitForSeconds(0.25f);
        PlayImage.rectTransform.sizeDelta = new Vector2(200, 100);
        PlayImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        SceneManager.LoadScene(22);
    }
    private IEnumerator OptionWait()
    {
        OptionsImage.color = new Color(255, 255, 0, 255);
        OptionsImage.rectTransform.sizeDelta = new Vector2(140, 40);

        yield return new WaitForSeconds(0.25f);
        OptionsImage.rectTransform.sizeDelta = new Vector2(150, 50);
        OptionsImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Options_Menu.SetActive(true);
        Main_Menu.SetActive(false);
        Debug.Log("Entered Option Menu Successfully");
    }
    private IEnumerator CreditWait()
    {
        CreditImage.color = new Color(255, 255, 0, 255);
        CreditImage.rectTransform.sizeDelta = new Vector2(140, 40);

        yield return new WaitForSeconds(0.25f);
        CreditImage.rectTransform.sizeDelta = new Vector2(150, 50);
        CreditImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Debug.Log("Entered Credit");
        Credit_Menu.SetActive(true);
        Main_Menu.SetActive(false);
    }
    private IEnumerator ExitWait()
    {
        ExitImage.color = new Color(255, 255, 0, 255);
        ExitImage.rectTransform.sizeDelta = new Vector2(90, 40);

        yield return new WaitForSeconds(0.25f);
        ExitImage.rectTransform.sizeDelta = new Vector2(100, 50);
        ExitImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Debug.Log("Quit!");
        Application.Quit();
    }

}