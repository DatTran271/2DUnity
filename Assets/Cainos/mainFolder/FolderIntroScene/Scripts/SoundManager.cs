using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public AudioSource audioSource;
    public AudioSource audioSource1;
    public AudioSource audioSource2;
    public AudioSource audioSource3;
    public AudioSource audioSource4;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(instance);
        }
    }

    public void PlayClip(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
        audioSource1.PlayOneShot(clip);
        audioSource2.PlayOneShot(clip);
        audioSource3.PlayOneShot(clip);
        audioSource4.PlayOneShot(clip);
    }
    public void StopClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource1.Stop();
        audioSource2.Stop();
        audioSource3.Stop();
        audioSource4.Stop();
    }
}
