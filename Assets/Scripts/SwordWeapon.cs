using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameManager.instance.hpAmount -= 1.0f * Time.deltaTime;
            GameManager.instance.hp--;
        }
    }
}
