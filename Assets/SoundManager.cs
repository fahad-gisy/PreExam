using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _smallDoor, _buttonPress,_mainKey;

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
}
