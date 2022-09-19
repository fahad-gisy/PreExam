using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   private bool _buttonActive, _press;
   private bool _key1, _greenButton, _redButton, _blueButton,_purpleButton;
   private bool _smToggle = true,_smToggle1 = true,_smToggle2 = true,_smToggle3 = true;
   private bool _smToggleButton = true,_smToggleButton1 = true,_smToggleButton2 = true,_smToggleButton3 = true;
   [SerializeField] private GameObject keyPadCanvas;
   [SerializeField] private SoundManager _sm;
   
   private static readonly int OpenClose = Animator.StringToHash("OpenClose");
   private static readonly int Open = Animator.StringToHash("Open");
   private static readonly int Press = Animator.StringToHash("Press");

   [SerializeField] private GameObject MessagePanel;
   private void OnTriggerStay(Collider other)
   {
      
      //__________________(MainDoor)____________________
      if (other.CompareTag("Key1"))
      {
         _sm.PlayMainKay();
         _key1 = !_key1;
         keyPadCanvas.SetActive(true);
         Destroy(other.gameObject);
      }

      // if (other.CompareTag("LockedDoor1"))
      // {
      //    if (_key1)
      //    {
      //       Animator anim = other.GetComponentInChildren<Animator>();
      //       anim.SetBool(Open,true);
      //    }
      // }
      //_________________(Green)______________________________
      if (other.CompareTag("GreenButton"))
      {
         _buttonActive = true;
         if (_press)
         {
            if (_smToggleButton3)
            {
               _sm.PlayButtonPress();
               _smToggleButton3 = !_smToggleButton3;
            }

            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(Press, true);
            _greenButton = true;
         }
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
         _buttonActive = true;
         if (_press)
         {
            if (_smToggleButton2)
            {
               _sm.PlayButtonPress();
               _smToggleButton2 = !_smToggleButton2;
            }
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(Press,true);
            _blueButton = true;
         }
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
         _buttonActive = true;
         if (_press)
         {
            if (_smToggleButton1)
            {
               _sm.PlayButtonPress();
               _smToggleButton1 = !_smToggleButton1;
            }
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(Press,true);
            _redButton = true;
         }
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
         _buttonActive = true;
         if (_press)
         {
            if (_smToggleButton)
            {
               _sm.PlayButtonPress();
               _smToggleButton = !_smToggleButton;
            }
            Animator anim = other.GetComponentInChildren<Animator>();
            anim.SetBool(Press,true);
            _purpleButton = true;
         }
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
//_______________________________________________________________________
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Door"))
      {

         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(OpenClose, true);
         _sm.PlaySmallDoor();

      }

   }
//__________________________________________________________________________
   private void OnTriggerExit(Collider other)
   {
      if (other.CompareTag("Door"))
      {
         _sm.PlaySmallDoor();
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool(OpenClose, false);
      }
      
      if (other.CompareTag("GreenButton"))
      {
         _buttonActive = false;
         MessagePanel.SetActive(false);
         _press = false;
      }
      if (other.CompareTag("BlueButton"))
      {
         _buttonActive = false;
         MessagePanel.SetActive(false);
         _press = false;
      }
      if (other.CompareTag("RedButton"))
      {
         _buttonActive = false;
         MessagePanel.SetActive(false);
         _press = false;
      }
      if (other.CompareTag("PurpleButton"))
      {
         _buttonActive = false;
         MessagePanel.SetActive(false);
         _press = false;
      }
      
   }

   private void Update()
   {
      if (_buttonActive)
      {
         MessagePanel.SetActive(true);
         if (Input.GetKeyDown(KeyCode.E))
         {
            _press = true;
         }
      }

   }
}
