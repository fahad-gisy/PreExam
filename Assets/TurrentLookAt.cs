using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurrentLookAt : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject bullet;
    
    void Start()
    {
        InvokeRepeating("Fire",0,1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(playerTransform);
        
        
       
    }

   


    private void Fire()
    {
       
        
        {
            Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        }
        
    }
}
