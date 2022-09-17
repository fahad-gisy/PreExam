using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _smallDoor, _buttonPress,_mainKey;
    [SerializeField] private AudioClip stop,keyPadSound;

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    public void PlaySmallDoor()
    {
        _audioSource.PlayOneShot(_smallDoor);
    }

    public void PlayButtonPress()
    {
        _audioSource.PlayOneShot(_buttonPress);
    }
    
    public void PlayMainKay()
    {
        _audioSource.PlayOneShot(_mainKey);
    }
    
    public void PlayEnemySayingStop()
    {
        _audioSource.PlayOneShot(stop);
    }
    public void PlayKeyPadSound()
    {
        _audioSource.PlayOneShot(keyPadSound);
    }
}
