using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovements : MonoBehaviour
{
   
    [SerializeField] private float speed;
    public CharacterController characterController;
    private Vector3 Velcoity;
    public float gravity = -9.81f;
    [SerializeField] private float mouseSpeed;
    public Transform playerTransform;
    [SerializeField] private float jumpH;
    private Vector3 movementVector3 = Vector3.zero;
    private float mouseInputRotateX;
    [SerializeField] private GameObject canvasInfo;

   
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        mouseInputRotateX =  Input.GetAxis("Mouse X");
        
        // mouseInputRotateY = Input.GetAxis("Mouse Y");
        StartCoroutine(canvasInfoHide());
    }

    IEnumerator canvasInfoHide()
    {
        yield return new WaitForSeconds(10f);
        canvasInfo.SetActive(false);
    }

    private void FixedUpdate()
    {

       
        
        float inputH = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float inputV = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        
         movementVector3 = transform.right * inputH + transform.forward * inputV;
        characterController.Move(movementVector3);
        
        Velcoity.y += gravity * Time.deltaTime;
        characterController.Move(Velcoity * Time.deltaTime);
        
        playerTransform.Rotate(Vector3.up * mouseSpeed * mouseInputRotateX * Time.deltaTime);
        

    }

   

}
