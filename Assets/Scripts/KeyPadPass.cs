using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyPadPass : MonoBehaviour
{
 [SerializeField] private TextMeshProUGUI resultText;
 private Animator _animator;
 [SerializeField] private PlayerMovements _playerMovements;
 [SerializeField] private SwordAnim _swordAnim;
 [SerializeField] private SoundManager _soundManager;
 
 private float distence
 {
  get { return Vector3.Distance(transform.position, _playerMovements.transform.position); }
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
  _playerMovements.enabled = false;
  _swordAnim.enabled = false;
  resultText.text += num.ToString();
 }

 public void Execute()
 {
  
  _playerMovements.enabled = true;
  _swordAnim.enabled = true;
  
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
