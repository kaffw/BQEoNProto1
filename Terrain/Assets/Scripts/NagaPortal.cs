using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagaPortal : MonoBehaviour
{
    public GameObject player;
    public GameObject portalExit;
    private Vector2 portalExitPos;
    void Start()
    {
        player = GameObject.Find("Bulan");
        portalExitPos = new Vector2(portalExit.transform.position.x, portalExit.transform.position.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.transform.position = portalExitPos;
        }
    }
}
