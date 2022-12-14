using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadPass : MonoBehaviour
{
 [SerializeField] private TextMeshProUGUI resultText;
 private Animator _animator;
 [SerializeField] private SoundManager _soundManager;
 [SerializeField] private ThirdPersonShooterController _thirdPersonShooterController;
 
 private float distence
 {
  get { return Vector3.Distance(transform.position, _thirdPersonShooterController.transform.position); }
 }

 private void Awake()
 {
  _animator = GetComponent<Animator>();
 }

 private string answer = "3517";
 private static readonly int OpenKeyDoor = Animator.StringToHash("OpenKeyDoor");
 [SerializeField] private GameObject canvasKeyPad;
 [SerializeField] private GameObject camSwitch;

 public void Number(int num)
 {
 _soundManager.PlayKeyPadSound();
  camSwitch.SetActive(true);
  resultText.text += num.ToString();
 }

 public void Execute()
 {
  

  
  _soundManager.PlayKeyPadExecuteButton();
  
  if (resultText.text == answer)
  {
   camSwitch.SetActive(false);
   _animator.SetBool(OpenKeyDoor,true);
   canvasKeyPad.SetActive(false);
  }

  if (resultText.text != answer)
  {
   resultText.text = "";
   camSwitch.SetActive(false);
  }

 }

 private void Update()
 {
  if (camSwitch.activeSelf&& distence > 10)
  {
   camSwitch.SetActive(false);
  }
 }
}
