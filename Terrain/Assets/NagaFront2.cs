using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagaFront2 : MonoBehaviour
{
    public GameObject dynamicBackground;
    public Rigidbody2D dynamicBackgroundRB;
    public GameObject Target;
    void Start()
    {
        Target = GameObject.Find("Bulan");
        dynamicBackgroundRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position = new Vector2(Target.transform.position.x / -8 + 120, 5);
    }
}
