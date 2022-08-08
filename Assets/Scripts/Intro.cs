using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //para controlar as cenas
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Text AnyKeyText;


    //variável para armazenar o nome da cena para localizá-la posteriormente
    //[SerializeField] private string nomeJogo;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.timeSinceLevelLoad > 2)
        //{
            //if ((int)(Time.timeSinceLevelLoad * 2) % 2 == 0)
                //AnyKeyText.gameObject.SetActive(true);
            //else
                //AnyKeyText.gameObject.SetActive(false);
        //}
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
            //Debug.Log("A key or mouse click has been detected");
        }

    }


}







