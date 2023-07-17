using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PseudoStalactites : MonoBehaviour
{
    private float fallDelay = 0.5f;
    private float destroyDelay = 3f;

    [SerializeField] private Rigidbody2D myrb;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Fall());
        }
    }
    private IEnumerator Fall()
    {
        yield return new WaitForSeconds(fallDelay);
        myrb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, destroyDelay);
    }
}