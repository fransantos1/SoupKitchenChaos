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
        masterVolume.value = 0.75f;
        sfxVolume.value = 1;
        musicVolume.value = 0.25f;
        OnMasterVolumeChanged(masterVolume.value);
        OnSFXVolumeChanged(sfxVolume.value);
        OnMusicVolumeChanged(musicVolume.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMasterVolumeChanged(float v)
    {
        audioMixer.SetFloat("MasterVolume", ToDecibel(v));
    }
    public void OnSFXVolumeChanged(float v)
    {
        audioMixer.SetFloat("SFXVolume", ToDecibel(v));
    }
    public void OnMusicVolumeChanged(float v)
    {
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
