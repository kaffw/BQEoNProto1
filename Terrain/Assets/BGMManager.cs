using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource BGMVolume;

    void Start()
    {
        BGMVolume = GetComponent<AudioSource>();
        BGMVolume.volume = 1;
    }

    void Update()
    {
        BGMVolume.volume = VolumeManagerSub.BGMVolumeSub;
    }
}
