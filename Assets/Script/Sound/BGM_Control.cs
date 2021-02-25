using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class BGM_Control : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip sound;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.volume = DataCenter.instance.gameData.volume;

        audioSource.loop = true;
        audioSource.Play();
    }

    void Update()
    {
        audioSource.volume = DataCenter.instance.gameData.volume;
        if (audioSource.isPlaying == false)
            audioSource.Play();
    }
}
