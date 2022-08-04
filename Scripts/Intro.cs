using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Intro : MonoBehaviour
{
    public Text AnyKeyText;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.anyKey)
        {
            SceneManager.LoadScene("Menu");
            //Debug.Log("A key or mouse click has been detected");
        }

    }


}







