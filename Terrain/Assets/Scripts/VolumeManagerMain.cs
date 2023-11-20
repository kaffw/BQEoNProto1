using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour
{
    public Slider BGM;
    static public float BGMVolume;
    [SerializeField] public GameObject BGMSettings;

    void Awake()
    {
        BGM = BGMSettings.GetComponent<Slider>();
    }

    void Update()
    {
        BGMVolume = BGM.value;
        //Debug.Log(BGM.value);
    }
}
