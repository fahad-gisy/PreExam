using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
  [SerializeField] private string gameScene;
  public void ReturnToMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
  }
  
  public void StartButton()
  {
    SceneManager.LoadScene("SampleScene");
  }

  public void QuitGame()
  {
    Application.Quit();
  }

 

  
}
