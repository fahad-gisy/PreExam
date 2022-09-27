using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTable : MonoBehaviour
{
    [SerializeField] private ThirdPersonShooterController _thirdPersonShooterController;
    [SerializeField] private GameObject TableGun;
    [SerializeField] private SoundManager _sm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            TableGun.SetActive(false);
            _sm.PlayPicUpGun();
            _thirdPersonShooterController.gun.SetActive(true);
           _thirdPersonShooterController.canAim = true;
        }
    }
}
