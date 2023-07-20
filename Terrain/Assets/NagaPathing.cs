using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NagaPathing : MonoBehaviour
{
    private Rigidbody2D nagaRB;
    private Animator nagaAnim;

    public GameObject Target;
    public Vector2 TargetPos;

    public bool faceDirection = true;

    //y
    public bool up = true, down = false;

    //levitaion
    public float levitateTimer = 0f;
    public float floatSpeed = 1.25f;
    void Start()
    {
        nagaRB = GetComponent<Rigidbody2D>();
        nagaAnim = GetComponent<Animator>();
        Target = GameObject.Find("Bulan");
        TargetPos = new Vector2(Target.transform.position.x, Target.transform.position.y);
    }

    void Update()
    {
        TargetPos = new Vector2(Target.transform.position.x, Target.transform.position.y); //Debug.Log(TargetPos);   


        Levitator();
        UpdateAnimation();
    }

    private void Levitator()
    {
        if (levitateTimer <= 10f)
        {
            levitateTimer += Time.deltaTime;
        }

        if (levitateTimer >= 0f && levitateTimer <= 2f)
        {
            //Naga goes up
            nagaRB.transform.position = new Vector2(nagaRB.transform.position.x, nagaRB.transform.position.y + Time.deltaTime);//+ (floatSpeed + Time.deltaTime));
        }

        if (levitateTimer >= 2.1f && levitateTimer <= 4f)
        {
            //Naga goes down
            nagaRB.transform.position = new Vector2(nagaRB.transform.position.x, nagaRB.transform.position.y - Time.deltaTime);//+ (-floatSpeed + Time.deltaTime));
        }

        if (levitateTimer > 4f) levitateTimer = 0f;

    }
    private void UpdateAnimation()
    {
        if (nagaRB.transform.position.x < Target.transform.position.x && faceDirection)
        {
            faceDirection = !faceDirection;
            transform.Rotate(0f, 180f, 0f);
        }
        else if (nagaRB.transform.position.x > Target.transform.position.x && !faceDirection)
        {
            faceDirection = !faceDirection;
            transform.Rotate(0f, 180f, 0f);
        }
    }

}
