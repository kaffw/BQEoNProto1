using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidScript : MonoBehaviour
{
    //public static CameraController Instance;

    public GameObject Target; //insert camera??
    public GameObject acid;
    [SerializeField] public float camSpeed = 1.5f;

    public Coroutine my_co;

    void Update()
    {
        Vector3 Targetpos = new Vector3(Target.transform.position.x, acid.transform.position.y, 0); //+camSpeed
        transform.position = Vector3.Lerp(transform.position, Targetpos, Time.deltaTime * camSpeed);
    }
}
