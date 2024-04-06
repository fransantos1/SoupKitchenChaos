using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System;

public class AudioManager1 : MonoBehaviour
{

    public float musicVolume;
    public float soundEffect_Volume;


    public Sound[] sounds;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound s in sounds)
        {

            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }

        musicVolume = 0.5f;
        soundEffect_Volume = 0.5f;

        Play("Music");
    }
 

    // Update is called once per frame
    public void Play(string name)
    {
        Sound original = Array.Find(sounds, sound => sound.name == name);

        Sound s = new Sound();
        s = original;

        if (name == "Music")
        {
            if (s.source.isPlaying)
            {
          
                s.source.volume = original.volume * musicVolume;
            }
            else
            {
                s.source.volume = original.volume * musicVolume;
                s.source.Play();
            }
      
        }
        else
        {
            //s.source.pitch = UnityEngine.Random.Range(0.9f, 1.15f);
            s.source.volume = original.volume * soundEffect_Volume;
            if (s.source.isPlaying)
            {
                s.source.Stop();
                s.source.Play();
            }
            else
            {
                s.source.Play();
            }

           
        }
        //Debug.Log(s.source.volume);

       

    }

    public void setMusicVolume()
    {
        float volume = GameObject.FindGameObjectWithTag("MusicOptionSlider").gameObject.GetComponent<Slider>().value;
        musicVolume = volume;
        Play("Music");
    }

    public void setEffectsVolume()
    {
        float effectsVolume = GameObject.FindGameObjectWithTag("SoundOptionSlider").gameObject.GetComponent<Slider>().value;

        soundEffect_Volume = effectsVolume;
    }
}
