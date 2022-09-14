using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public float hp = 100f;
    [SerializeField] public Image hpBar;
    [SerializeField] public float hpAmount = 1f;
    [SerializeField] private AudioClip gunSound;
    [SerializeField] private AudioSource _audioSource;
    private GameObject cam;
    [SerializeField] private Camera _camera;

    private void Awake()
    {
        instance = this;
        cam = GameObject.FindWithTag("Vcam");
    }

    private void Update()
    {
        hpBar.fillAmount = hpAmount;
        
    }

    
}
