using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   private bool _Key1;
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Door"))
      {
         
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool("OpenClose",true);

      }

      if (other.CompareTag("Key1"))
      {
         _Key1 = !_Key1;
         Debug.Log(_Key1);
         Destroy(other.gameObject);
      }

      if (other.CompareTag("LockedDoor1"))
      {
         if (_Key1)
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
