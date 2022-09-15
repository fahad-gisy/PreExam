using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour
{
    private Animator _animator;
    private PlayerMovements _playerMovements;
    private static readonly int Pwalking = Animator.StringToHash("Pwalking");
    private static readonly int PwalkingLeft = Animator.StringToHash("PwalkingLeft");

    [SerializeField] private float Vertical = 0.0f; // W or S
    [SerializeField] private float Horzental = 0.0f; // A OR D

   [SerializeField] private float acceleration = 2.0f;
   [SerializeField] private float deAcceleration = 2.0f;

    
    

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerMovements = GetComponent<PlayerMovements>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Z))
        {
            _animator.SetLayerWeight(1,1f);
        }
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            _animator.SetLayerWeight(1,0f);
        }
        
        
        bool Wpressed = Input.GetKey(KeyCode.W);
        bool leftPressed = Input.GetKey(KeyCode.A);
        bool rightPressed = Input.GetKey(KeyCode.D);
        bool backPressed = Input.GetKey(KeyCode.S);

        if (Wpressed && Vertical < 1.0f)
        {
            Vertical += Time.deltaTime * acceleration;
        }

        if (!Wpressed && Vertical > 0.0f)
        {
            Vertical -= Time.deltaTime * deAcceleration;
        }

        if (backPressed && Vertical > -1f)
        {
            Vertical -= Time.deltaTime * deAcceleration;
        }

        if (!backPressed && Vertical < 0f)
        {
            Vertical += Time.deltaTime * acceleration;
        }

        if (leftPressed && Horzental > -1f)
        {
            Horzental -= Time.deltaTime * deAcceleration;
        }

        if (!leftPressed && Horzental < 0)
        {
            Horzental += Time.deltaTime * acceleration;
        }
        
        if (rightPressed && Horzental < 1.0f)
        {
            Horzental += Time.deltaTime * acceleration;
        }

        if (!rightPressed &&  Horzental > 0.0f)
        {
            Horzental -= Time.deltaTime * deAcceleration;
        }
        
        _animator.SetFloat("Horzental",Horzental);
        _animator.SetFloat("Vertical",Vertical);
        
    }
}
