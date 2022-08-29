using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TimeHandler : MonoBehaviour
{
    public GameManager GM;
    public float Countdown;
    public Text countdownText;

    // Update is called once per frame
    void Update() {
        if (!GM.isEndgame) {
            Countdown = Mathf.Clamp(Countdown - Time.deltaTime, 0, 100);
            countdownText.text = Mathf.CeilToInt(Countdown).ToString();
            
            if (Countdown <= 0) {
                GM.Die();
            }
        }
    }
}
