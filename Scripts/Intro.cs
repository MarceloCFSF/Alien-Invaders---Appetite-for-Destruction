using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //para controlar as cenas
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public float anyKeyText;
    [SerializeField] private Text AnyKeyText;


    //variável para armazenar o nome da cena para localizá-la posteriormente
    //[SerializeField] private string nomeJogo;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    //Faz o texto piscar
    anyKeyText = Mathf.PingPong(Time.time, 1f);
    
    Color color = GetComponent<Text>().color;
    GetComponent<Text>().color = new Vector4(color.r, color.g, color.b, anyKeyText);
    

    //Verifica se o usuário pressionou alguma tecla
    if (Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
            //Debug.Log("A key or mouse click has been detected");
        }

    }


}







