using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public bool ifWithinRadius = false;
    public GameObject DialogueLog;

    public GameObject Player;
    public Vector2 Target;

    private GameObject NPC;
    private Vector2 NPCPosition;

    public GameObject TalkIndicator;
    public static bool TalkIndicatorIfDestroy = false;

    public static bool inDialogue = false;

    public static bool talkIndicatorDestroy = true;

    public static int InstanceLimit = 0;
    void Awake()
    {
        Player = GameObject.Find("Character");
        NPC = GameObject.Find("NPC");
        NPCPosition = new Vector2(NPC.transform.position.x, NPC.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ifWithinRadius = true;
            Instantiate(TalkIndicator, NPCPosition + new Vector2(0, 2), transform.rotation);
            TalkIndicatorIfDestroy = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ifWithinRadius = false;
            TalkIndicatorIfDestroy = true;
        }
    }

    public void Update()
    {
        if (Input.GetKeyDown("k") && ifWithinRadius == true && InstanceLimit == 0)
        {
            Target = new Vector2(Player.transform.position.x, Player.transform.position.y - 2);
            Instantiate(DialogueLog, Target, transform.rotation);
            inDialogue = true;
            InstanceLimit++;
        }
    }
}