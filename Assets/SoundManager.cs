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

<<<<<<< HEAD
    public void StopSound()
    {
        _audioSource.PlayOneShot(GameManager.instance.stop);
=======
    public void PlayMainKay()
    {
        _audioSource.PlayOneShot(_mainKey);
>>>>>>> cfac5c00f1a7c28aa20cdcc35a275b650ecdbc98
    }
}
