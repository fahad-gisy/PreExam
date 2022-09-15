using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
  
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
