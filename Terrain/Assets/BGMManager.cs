using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    public AudioSource BGMVolume;

    void Start()
    {
        BGMVolume = GetComponent<AudioSource>();
        BGMVolume.volume = VolumeManager.BGMVolume;
    }

    void Update()
    {
        BGMVolume.volume = VolumeManager.BGMVolume;
    }
}
