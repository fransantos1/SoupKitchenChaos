using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSliderController : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Slider masterVolume;

    // Start is called before the first frame update
    void Start()
    {
        OnMasterVolumeChanged(masterVolume.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMasterVolumeChanged(float v)
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
