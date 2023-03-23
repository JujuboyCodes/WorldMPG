using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Slider soundfxSlider;


    void Start()
    {
        ApplyVolume();
        volumeSlider.value = playerData.VolumeLevel;
        soundfxSlider.value = playerData.VolumeLevel;
    }

    void ApplyVolume()
    {
        AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = playerData.VolumeLevel;
        }
    }

     public void SetVolumeLevel(float value)
    {
        playerData.VolumeLevel = volumeSlider.value;
    }

     public void SetSoundfxLevel(float value)
    {
        playerData.SoundFxLevel = soundfxSlider.value;
    }
}
