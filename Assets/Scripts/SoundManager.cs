using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource _audioSource;
    [SerializeField] private AudioClip _smallDoor, _buttonPress,_mainKey;
    [SerializeField] private AudioClip stop,keyPadSound,executeButton;
    [SerializeField] private AudioClip _gunShoot,gunPickUp;

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
    
    public void PlayKeyPadExecuteButton()
    {
        _audioSource.PlayOneShot(executeButton);
    }

    public void PlayGunShoot()
    {
        _audioSource.PlayOneShot(_gunShoot);
    }

    public void PlayPicUpGun()
    {
        _audioSource.PlayOneShot(gunPickUp);
    }
}
