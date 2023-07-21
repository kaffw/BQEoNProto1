using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{
    public GameObject brokenbit;

    public GameObject FixedCrate;

    public GameObject drop;
    public Vector2 Target;

    void Start()
    {
        Target = new Vector2(brokenbit.transform.position.x, FixedCrate.transform.position.y);

        Target = new Vector2(FixedCrate.transform.position.x, FixedCrate.transform.position.y);
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
        GameObject broke = (GameObject)
        Instantiate(brokenbit, Target + new Vector2(1, 3), Quaternion.identity);
        Instantiate(drop, Target + new Vector2(1, 3), Quaternion.identity);

        foreach (Transform child in broke.transform)
        {
            child.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(3f, 7f));
            drop.GetComponent<Rigidbody2D>().velocity = new Vector2(Random.Range(-2f, 2f), Random.Range(3f, 7f));
        }

    }
}
