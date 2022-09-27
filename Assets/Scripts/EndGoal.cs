using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
       //end goal trigger with player
       if (other.CompareTag("Player"))
       {
           Cursor.visible = true;
                  Cursor.lockState = CursorLockMode.Confined;
                  SceneManager.LoadScene("WinMenu");
       }
       
      
           
    }
}
