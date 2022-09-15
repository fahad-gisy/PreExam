using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   private bool _key1, _greenButton, _redButton, _blueButton,_purpleButton;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Door"))
      {
         
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool("OpenClose",true);

      }
      //__________________(MainDoor)____________________
      if (other.CompareTag("Key1"))
      {
         _key1 = !_key1;
         Destroy(other.gameObject);
      }

      if (other.CompareTag("LockedDoor1"))
      {
         if (_key1)
         {
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("Open",true);
         }
      }
      //_________________(Green)______________________________
      if (other.CompareTag("GreenButton"))
      {
         _greenButton = !_greenButton;
            Debug.Log("Green Door is:"+_greenButton);
      }

      if (other.CompareTag("GreenDoor"))
      {
         if (_greenButton)
         {
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("OpenClose",true);
         }
      }
      //__________________(Blue)_________________________________
      if (other.CompareTag("BlueButton"))
      {
         _blueButton = !_blueButton;
         Debug.Log("Blue Door is:"+_blueButton);
      }

      if (other.CompareTag("BlueDoor"))
      {
         if (_blueButton)
         {
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("OpenClose",true);
         }
      }
      //____________________(Red)_______________________________
      if (other.CompareTag("RedButton"))
      {
         _redButton = !_redButton;
         Debug.Log("The Red Door is:"+_redButton);
      }

      if (other.CompareTag("RedDoor"))
      {
         if (_redButton)
         {
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("OpenClose",true);
         }
      }
      //______________________(Purple)_________________________
      if (other.CompareTag("PurpleButton"))
      {
         _purpleButton = !_purpleButton;
         Debug.Log("The Purple Door is:"+_purpleButton);
      }

      if (other.CompareTag("PurpleDoor"))
      {
         if (_purpleButton)
         {
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool("Open",true);
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Door"))
      {
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool("OpenClose",false);
      }
   }
}
