using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject brokenbit;
    void OntriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Projectile")
            BreakIt();
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Projectile")
        {
            BreakIt();
        }
    }
    public void BreakIt()
    {
        Destroy(this.gameObject);
        GameObject broke = (GameObject)Instantiate(brokenbit, transform.position, Quaternion.identity);
        foreach (Transform child in broke.transform)
        {
            child.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(3f, 7f));
        }
    }
}