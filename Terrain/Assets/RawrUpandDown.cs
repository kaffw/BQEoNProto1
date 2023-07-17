using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class RawrUpandDown : MonoBehaviour
{
    public GameObject Target;
    public GameObject Character_Target;
    
    [SerializeField] public float RawrMoveSpeed = 2f;
    //public float speed = 1.55f;
    public Coroutine my_co;

    void Update()
    {
        Vector3 Targetpos = new Vector3(Target.transform.position.x + RawrMoveSpeed, Character_Target.transform.position.y, 0f);
        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * RawrMoveSpeed);
    }
}
