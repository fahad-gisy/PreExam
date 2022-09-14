using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Door"))
      {
         
         Animator anim = other.GetComponentInChildren<Animator>();
         anim.SetBool("OpenClose",true);

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
