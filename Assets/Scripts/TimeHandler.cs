using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TimeHandler : MonoBehaviour
{
    public float Countdown;
    public Text countdownText;

    // Update is called once per frame
    void Update() {
        Countdown = Mathf.Clamp(Countdown - Time.deltaTime, 0, 100);
        countdownText.text = Mathf.CeilToInt(Countdown).ToString();
        
        if (Countdown <= 0) {
            SceneManager.LoadScene("Intro");
        }

    }
}
