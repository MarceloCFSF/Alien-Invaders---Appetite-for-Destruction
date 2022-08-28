using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class TimeHandler : MonoBehaviour
{
    public float Countdown;
    public Text countdownText;
    [SerializeField] private GameObject winGame;
    [SerializeField] private GameObject loseGame;

    // Update is called once per frame
    void Update() {
        Countdown = Mathf.Clamp(Countdown - Time.deltaTime, 0, 100);
        countdownText.text = Mathf.CeilToInt(Countdown).ToString();
        
        if (Countdown <= 0) {
            //ativa a imagem de vencedor
            winGame.SetActive(true);

            //ativa a imagem de perdedor
            //loseGame.SetActive(true);
        }

    }
}
