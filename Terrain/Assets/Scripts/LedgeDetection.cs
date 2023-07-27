using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeDetection : MonoBehaviour
{
    [SerializeField] private float radius;
    [SerializeField] private moveset player;
    [SerializeField] private LayerMask whatIsGround;


    private bool canDetect;



    private void onDrawGizmos(){

        Gizmos.DrawSphere(transform.position,radius);
    }
    private void update(){
        if(canDetect){
            player.LedgeDetected = Physics2D.OverlapCircle(transform.position,radius);
        }





    }

    private void OnTriggerEnter2D(Collider2D collision){


        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            canDetect = true;

    }

    private void OnTriggerExit2D(Collider2D collision){


        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
            canDetect = false;

    }

}
