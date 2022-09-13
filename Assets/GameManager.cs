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

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        hpBar.fillAmount = hpAmount;
    }
}
