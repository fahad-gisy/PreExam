using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    private float timer;
    [SerializeField] private float TimeToCountDown;
    [SerializeField] private TextMeshProUGUI timeText;
    //this will let us keep track of the time
    
    void Start()
    {
        timer = TimeToCountDown;
    }
    
    void Update()
    {
        timeText.text = timer.ToString("0000");
        CountDown();
        if (timer <= 0)
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            SceneManager.LoadScene("LoseScene");
            timer = 0;
        }
        
    }

    public void CountDown()
    {//remove Time,deltaTime from timer each frame
        timer -= Time.deltaTime;
    }
    
    
}
