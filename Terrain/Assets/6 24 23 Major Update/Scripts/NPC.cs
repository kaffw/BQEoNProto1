using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NPC : MonoBehaviour
{
    public GameObject dialoguePanel;
    public TextMeshProUGUI dialogueText;
    public string[] dialogue;
    private int index = 0;

    public float wordSpeed;
    public bool playerIsClose;

    public bool ifWithinRadius = false;
    public GameObject Player;
    public Vector2 Target;

    private GameObject NPCaaa;
    private Vector2 NPCPosition;

    public GameObject TalkIndicator;
    public static bool TalkIndicatorIfDestroy = false;

    public static bool inDialogue = false;

    public static bool talkIndicatorDestroy = true;

    public static int InstanceLimit = 0;

    public bool ifSkip = false;
    public int pressCount = 0;
    void Awake()
    {
        Player = GameObject.Find("Bulan");
        NPCaaa = GameObject.Find("NPC");
        NPCPosition = new Vector2(NPCaaa.transform.position.x, NPCaaa.transform.position.y);
    }
    void Start()
    {
        dialogueText.text = "";
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerIsClose && ifWithinRadius == true)
        {
            pressCount++;
            Target = new Vector2(Player.transform.position.x, Player.transform.position.y - 2);
            inDialogue = true;
            InstanceLimit++;

            if (!dialoguePanel.activeInHierarchy)
            {
                dialoguePanel.SetActive(true);
                StartCoroutine(Typing());
            }
            else if (dialogueText.text == dialogue[index])
            {
                NextLine();
            }

        }
        else if (Input.GetKeyDown(KeyCode.Q) && dialoguePanel.activeInHierarchy)
        {
            RemoveText();
        }

        //StartCoroutine(SkipDialogue());
        //Debug.Log(pressCount);
    }

    public void RemoveText()
    {
        dialogueText.text = "";
        index = 0;
        dialoguePanel.SetActive(false);
        pressCount = 0;
    }

    IEnumerator Typing()
    {
        foreach (char letter in dialogue[index].ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(wordSpeed);
        }
    }

    public void NextLine()
    {
        if (index < dialogue.Length - 1)
        {
            index++;
            dialogueText.text = "";
            StartCoroutine(Typing());
        }
        else
        {
            RemoveText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ifWithinRadius = true;
            Instantiate(TalkIndicator, NPCPosition + new Vector2(0, 2), transform.rotation);
            TalkIndicatorIfDestroy = false;
            playerIsClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ifWithinRadius = false;
            TalkIndicatorIfDestroy = true;
            playerIsClose = false;

            RemoveText();
        }
    }
    
    /*
    private IEnumerator SkipDialogue()
    {
        if (Input.GetKeyDown(KeyCode.E) && pressCount == 1)
        {
            NextLine();
            Debug.Log(pressCount);
            pressCount = 0;
        }
        yield return new WaitForSeconds(3f);
        //yield return null;
    }
    */
    
}
