using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeManagerSub : MonoBehaviour
{
    public Slider BGMSub;
    static public float BGMVolumeSub;
    [SerializeField] public GameObject BGMSettings;

    void Start()
    {
        BGMSub = BGMSettings.GetComponent<Slider>();
        BGMSub.value = VolumeManagerMain.BGMVolume;
        BGMVolumeSub = VolumeManagerMain.BGMVolume;//BGMSub.value;
    }

    void Update()
    {
        BGMVolumeSub = BGMSub.value;
        VolumeManagerMain.BGMVolume = BGMSub.value;
    }
}
