using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] public Image hpBar;
    [SerializeField] public float hpAmount = 1f;
    [SerializeField] public float hpAmountPlayer = 1f;
    [SerializeField] private AudioClip swordSlachClip;
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        hpBar.fillAmount = hpAmountPlayer;

        if (hpAmountPlayer <= 0)
        {
            SceneManager.LoadScene("LoseScene");
        }
     
    }

    public void SwordSlashSound()
    {
        _audioSource.PlayOneShot(swordSlachClip);
    }
    
    

    
}
