using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{
    [SerializeField] private ParticleSystem blood;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.hpAmountPlayer -= 2.0f * Time.deltaTime;
            
        }
    }
}
