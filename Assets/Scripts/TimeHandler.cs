using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TimeHandler : MonoBehaviour
{
    public GameManager GM;
    private float Countdown;
    public float maxTime = 200;
    public Text countdownText;

    private void Start() {
        Countdown = maxTime;
    }

    // Update is called once per frame
    void Update() {
        if (!GM.isEndgame) {
            Countdown = Mathf.Clamp(Countdown - Time.deltaTime, 0, maxTime);
            countdownText.text = Mathf.CeilToInt(Countdown).ToString();
            
            if (Countdown <= 0) {
                GM.Die();
            }
        }
    }
}
