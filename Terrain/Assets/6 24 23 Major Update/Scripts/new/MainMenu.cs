using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenu : MonoBehaviour
{
    public GameObject Play, Options, Exit;
    public GameObject Options_Menu, Main_Menu;
    public Color PlayColor, OptionsColor, ExitColor;
    public Color color;

    private Image PlayImage, OptionsImage, ExitImage;


    private void Awake()
    {
        PlayImage = Play.GetComponent<Image>();
        OptionsImage = Options.GetComponent<Image>();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator ExitWait()
    {
        ExitImage.color = new Color(255, 255, 0, 255);
        ExitImage.rectTransform.sizeDelta = new Vector2(190, 90);

        yield return new WaitForSeconds(0.25f);
        ExitImage.rectTransform.sizeDelta = new Vector2(200, 100);
        ExitImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Debug.Log("Quit!");
        Application.Quit();
    }

    private IEnumerator OptionWait()
    {
        OptionsImage.color = new Color(255, 255, 0, 255);
        OptionsImage.rectTransform.sizeDelta = new Vector2(190, 90);

        yield return new WaitForSeconds(0.25f);
        OptionsImage.rectTransform.sizeDelta = new Vector2(200, 100);
        OptionsImage.color = new Color(255, 255, 255, 255);

        yield return new WaitForSeconds(0.25f);
        Options_Menu.SetActive(true);
        Main_Menu.SetActive(false);
        Debug.Log("Entered Option Menu Successfully");
    }
    
}