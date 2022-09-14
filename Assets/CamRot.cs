using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRot : MonoBehaviour
{
    private float mouseY;

    private float xRotation = 0f;

    [SerializeField] private float mouseSpeed = 100f;
    [SerializeField] private float minClamp;
    [SerializeField] private float maxClamp;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouseY = Input.GetAxis("Mouse Y") * mouseSpeed * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, minClamp, maxClamp);
        
        transform.localRotation = Quaternion.Euler(xRotation,0f,0f);
    }
}
