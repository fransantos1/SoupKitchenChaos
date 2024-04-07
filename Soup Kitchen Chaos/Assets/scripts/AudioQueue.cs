using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class AudioQueue : MonoBehaviour
{
    [SerializeField] List<AudioClip> clips;
    [SerializeField] AudioSource source;

    private Queue<AudioClip> clipQueue = new Queue<AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0;i<clips.Count;i++)
        {
            clipQueue.Enqueue(clips[i]);
        }

        Shuffle();
        PlayNextClip();

    //    StartCoroutine(PlayMusic());

    }

    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.M))
        {
            PlayNextClip();
        } 

       if (!source.isPlaying && !source.mute)
        {
            PlayNextClip();
        }
    }

    private void PlayNextClip()
    {
        AudioClip originalClip = source.clip;

        if (originalClip != null)
        {
            clipQueue.Enqueue(originalClip);
        }

        AudioClip nextClip = clipQueue.Dequeue();
        source.clip = nextClip;
        source.Play();

    }

    void Shuffle()
    {
        System.Random rng = new System.Random();
        int n = clips.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            AudioClip value = clips[k];
            clips[k] = clips[n];
            clips[n] = value;
        }

        // Print shuffled list (for demonstration)
        foreach (var clip in clips)
        {
            Debug.Log(clip.name);
        }
    }
}
