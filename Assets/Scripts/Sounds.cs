using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public AudioClip backsound, sliceVoice, turningVoice;
    AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = backsound;
        audioSource.Play();
    }

    public void PlaySliceVoice(){
        audioSource.PlayOneShot(sliceVoice);
    }

    public void PlayTurnVoice(){
        audioSource.PlayOneShot(turningVoice);
    }


}
