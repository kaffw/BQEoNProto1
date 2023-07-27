using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorExplodeTrigger : MonoBehaviour
{
    private Animator meteorExp;
    private SpriteRenderer meteorSprite;

    public GameObject explosionMain;
    public SpriteRenderer explosionMainSprite;
    public MeteorFalling meteorFallingDisabler;
    void Start()
    {
        meteorExp = GetComponent<Animator>();
        meteorSprite = GetComponent<SpriteRenderer>();

        meteorSprite.color = new Color(0, 0, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" || collision.tag == "Terrain" )//|| collision.tag == "Untagged")
        {
            meteorFallingDisabler.enabled = false;
            meteorSprite.color = new Color(255, 255, 255, 255);
            explosionMainSprite.color = new Color(0, 0, 0, 0);
            meteorExp.SetTrigger("MeteorExplosion");
            Destroy(gameObject, 1.25f);
            Destroy(explosionMain, 1.25f);
        }
    }


}
