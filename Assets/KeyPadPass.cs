using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadPass : MonoBehaviour
{
 [SerializeField] private TextMeshProUGUI resultText;
 private Animator _animator;

 private void Awake()
 {
  _animator = GetComponent<Animator>();
 }

 private string answer = "123456";
 private static readonly int OpenKeyDoor = Animator.StringToHash("OpenKeyDoor");
 [SerializeField] private GameObject canvasKeyPad;

 public void Number(int num)
 {
  resultText.text += num.ToString();
 }

 public void Execute()
 {
  if (resultText.text == answer)
  {
   _animator.SetBool(OpenKeyDoor,true);
   canvasKeyPad.SetActive(false);
  }
  else
  {
   resultText.text = "TryAgain";
  }
 }
 
}
