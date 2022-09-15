using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   private bool _key1, _greenButton, _redButton, _blueButton,_purpleButton;
   private bool _smToggle = true,_smToggle1 = true,_smToggle2 = true,_smToggle3 = true;
   [SerializeField] private SoundManager _sm;
   private static readonly int OpenClose = Animator.StringToHash("OpenClose");
   private static readonly int Open = Animator.StringToHash("Open");
   private static readonly int Press = Animator.StringToHash("Press");

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Door"))
      {
         
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(OpenClose,true);
         _sm.PlaySmallDoor();

      }
      //__________________(MainDoor)____________________
      if (other.CompareTag("Key1"))
      {
         _sm.PlayMainKay();
         _key1 = !_key1;
         Destroy(other.gameObject);
      }

      if (other.CompareTag("LockedDoor1"))
      {
         if (_key1)
         {
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(Open,true);
         }
      }
      //_________________(Green)______________________________
      if (other.CompareTag("GreenButton"))
      {
         _sm.PlayButtonPress();
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(Press,true);
         _greenButton = !_greenButton;
            Debug.Log("Green Door is:"+_greenButton);
      }

      if (other.CompareTag("GreenDoor"))
      {
         if (_greenButton)
         {
            if (_smToggle3)
            {
               _sm.PlaySmallDoor();
               _smToggle3 = !_smToggle3;
            }
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(OpenClose,true);
         }
      }
      //__________________(Blue)_________________________________
      if (other.CompareTag("BlueButton"))
      {
         _sm.PlayButtonPress();
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(Press,true);
         _blueButton = !_blueButton;
         Debug.Log("Blue Door is:"+_blueButton);
      }

      if (other.CompareTag("BlueDoor"))
      {
         if (_blueButton)
         {
            if (_smToggle2)
            {
               _sm.PlaySmallDoor();
               _smToggle2 = !_smToggle2;
            }
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(OpenClose,true);
         }
      }
      //____________________(Red)_______________________________
      if (other.CompareTag("RedButton"))
      {
         _sm.PlayButtonPress();
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(Press,true);
         _redButton = !_redButton;
         Debug.Log("The Red Door is:"+_redButton);
      }

      if (other.CompareTag("RedDoor"))
      {
         if (_redButton)
         {
            if (_smToggle1)
            {
               _sm.PlaySmallDoor();
               _smToggle1 = !_smToggle1;
            }
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(OpenClose,true);
         }
      }
      //______________________(Purple)_________________________
      if (other.CompareTag("PurpleButton"))
      {
         _sm.PlayButtonPress();
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(Press,true);
         _purpleButton = !_purpleButton;
         Debug.Log("The Purple Door is:"+_purpleButton);
      }

      if (other.CompareTag("PurpleDoor"))
      {
         if (_purpleButton)
         {
            if (_smToggle)
            {
               _sm.PlaySmallDoor();
               _smToggle = !_smToggle;
            }
            
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(Open,true);
         }
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Door"))
      {
         _sm.PlaySmallDoor();
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(OpenClose,false);
      }
   }
}
