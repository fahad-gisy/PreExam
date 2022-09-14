using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FootSteps : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip[] randomAudioClips;
    
    
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void Steps()
    {
        AudioClip cilp = GetRandomCilp();
        _audioSource.PlayOneShot(cilp);
    }

    private AudioClip GetRandomCilp()
    {
        int index = Random.Range(0,randomAudioClips.Length - 1);

        return  randomAudioClips[index];
    }

   
    
}
