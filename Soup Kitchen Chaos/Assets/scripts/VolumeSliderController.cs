using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliderController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterVolume;

    public Slider sfxVolume;
   
    public Slider musicVolume;

    // Start is called before the first frame update
    void Start()
    {
        OnMasterVolumeChanged(AudioSettings.masterVolume);
        OnSFXVolumeChanged(AudioSettings.sfxVolume);
        OnMusicVolumeChanged(AudioSettings.musicVolume);

        masterVolume.value = AudioSettings.masterVolume;
        sfxVolume.value = AudioSettings.sfxVolume;
        musicVolume.value = AudioSettings.musicVolume;
    }

    public void OnMasterVolumeChanged(float v)
    {
        AudioSettings.masterVolume = v;
        audioMixer.SetFloat("MasterVolume", ToDecibel(v));
    }
    public void OnSFXVolumeChanged(float v)
    {
        AudioSettings.sfxVolume = v;
        audioMixer.SetFloat("SFXVolume", ToDecibel(v));
    }
    public void OnMusicVolumeChanged(float v)
    {
        AudioSettings.musicVolume = v;
        audioMixer.SetFloat("BGMVolume", ToDecibel(v));
    }

    private float ToDecibel(float amplitude)
    {
        if (amplitude <= 0f)
        {
            return -80f; // Minimum dB value (practically silent)
        }
        else
        {
            return 20f * Mathf.Log10(amplitude);
        }
    }
}
