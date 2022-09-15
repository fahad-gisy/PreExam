using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamge : MonoBehaviour
{
    // [SerializeField] private ParticleSystem blood;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            GameManager.instance.hpAmount -= 15.0f * Time.deltaTime;
            // blood.Play();
            // StartCoroutine(stopPlayingBlood());
        }
    }
    
    

    // // IEnumerator stopPlayingBlood()
    // {
    //     yield return new WaitForSeconds(0.3f);
    //     // blood.Stop();
    // }

}
