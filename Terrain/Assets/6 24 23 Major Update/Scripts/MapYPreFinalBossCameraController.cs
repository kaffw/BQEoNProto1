using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapYPreFinalBossCameraController : MonoBehaviour
{
    //public static CameraController Instance;

    public GameObject Target; //insert camera??
    public GameObject Character_Target;
    [SerializeField] public float camSpeed = 2.5f;

    public Coroutine my_co;
   
    void Update()
    {
        Vector3 Targetpos = new Vector3(Target.transform.position.x + camSpeed, Character_Target.transform.position.y, -7);
        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * camSpeed);
    }
}
