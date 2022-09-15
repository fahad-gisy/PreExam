using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float hp = 100f;
    [SerializeField] public Image hpBar;
    [SerializeField] public float hpAmount = 1f;
    [SerializeField] private AudioClip swordSlachClip;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] public float enemyHp;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        hpBar.fillAmount = hpAmount;
      

    }

    public void SwordSlashSound()
    {
        _audioSource.PlayOneShot(swordSlachClip);
    }

    
}
