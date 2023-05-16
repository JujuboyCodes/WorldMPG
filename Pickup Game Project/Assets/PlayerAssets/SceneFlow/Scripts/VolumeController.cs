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
        ApplySoundVolume();
        ApplySoundfxVolume();
        volumeSlider.value = playerData.VolumeLevel;
        soundfxSlider.value = playerData.VolumeLevel;
    }

    void ApplySoundVolume()
    {
        // Find the GameObject with the "MusicSource" tag (name it musicSource)
        GameObject musicSource = GameObject.FindWithTag("MusicSource");

        // Get all AudioSource components attached to the GameObject
        AudioSource[] audioSources = musicSource.GetComponents<AudioSource>();

        //AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = playerData.VolumeLevel;
        }
    }

      void ApplySoundfxVolume()
    {
        // Find the GameObject with the "SoundFxLevel" tag (name it soundfxSource)
        GameObject soundfxSource = GameObject.FindWithTag("SoundfxSource");

        // Get all AudioSource components attached to the GameObject
        AudioSource[] audioSources = soundfxSource.GetComponents<AudioSource>();

        //AudioSource[] audioSources = FindObjectsOfType<AudioSource>();
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.volume = playerData.SoundFxLevel;
        }
    }


     public void SetVolumeLevel(float value)
    {
        playerData.VolumeLevel = volumeSlider.value;
        ApplySoundVolume();
    }

     public void SetSoundfxLevel(float value)
    {
        playerData.SoundFxLevel = soundfxSlider.value;
         ApplySoundfxVolume();
    }
}
