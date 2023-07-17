using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceToSecret : MonoBehaviour
{
    public static int secretEntryState = 0;

    private float fallDelay = 1f;
    private float destroyDelay = 2f;

    [SerializeField] private Rigidbody2D myrb;

    private void Awake()
    {
        if(SecretEntrySM.secretEntryStatus == 1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision){
        if(collision.gameObject.CompareTag("Player")){
            SecretEntrySM.secretEntryStatus = 1;
            secretEntryState = 1;
            StartCoroutine(Fall());
        }
    }

    private IEnumerator Fall(){
        yield return new WaitForSeconds(fallDelay);
        myrb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}
