using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Button Button;
    public Button BtBack;



    void Start()
    {
        Button btn = BtBack.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = Button.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Menu");
    }

    void TaskOnClick2()
    {
        SceneManager.LoadScene("SampleScene");
    }





}
