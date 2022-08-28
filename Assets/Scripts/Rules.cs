using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //para controlar as cenas
using UnityEngine.UI;

public class Rules : MonoBehaviour
{
    private float anyKeyText;
    public Text AnyKeyText;
    
    public GameObject rules1;
    public GameObject rules2;

    private int option = 0;
    private float awaitTime = 2f;

    private void Update() {
        //Faz o texto piscar
        anyKeyText = Mathf.PingPong(Time.time, 1f);
        Color color = AnyKeyText.color;
        AnyKeyText.color = new Vector4(color.r, color.g, color.b, anyKeyText);

        //Verifica se o usuário pressionou alguma tecla
        awaitTime = Mathf.Clamp(awaitTime - Time.deltaTime, 0, 100);
        if (Input.anyKey && awaitTime <= 0) {
            if (option == 0) {
                rules1.SetActive(false);
                rules2.SetActive(true);

                option++;
                awaitTime=2f;
            } else {
                SceneManager.LoadScene("Main");
            }
        }
    }
}