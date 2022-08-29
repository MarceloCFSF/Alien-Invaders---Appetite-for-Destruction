using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Level : MonoBehaviour
{

    public Button BtBack;
    public Button BtL1;
    public Button BtL2;
    public Button BtL3;
    public Button BtL4;

    void Start()
    {
        Button btn = BtBack.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

        Button btn2 = BtL1.GetComponent<Button>();
        btn2.onClick.AddListener(TaskOnClick2);

        Button btn3 = BtL2.GetComponent<Button>();
        btn3.onClick.AddListener(TaskOnClick3);

        Button btn4 = BtL3.GetComponent<Button>();
        btn4.onClick.AddListener(TaskOnClick4);

        Button btn5 = BtL4.GetComponent<Button>();
        btn5.onClick.AddListener(TaskOnClick5);
    }

    void TaskOnClick()
    {
        SceneManager.LoadScene("Menu");
    }

    void TaskOnClick2()
    {
        SceneManager.LoadScene("Main");
    }

    void TaskOnClick3()
    {
        SceneManager.LoadScene("Level2");
    }

    void TaskOnClick4()
    {
        SceneManager.LoadScene("Level3");
    }

    void TaskOnClick5()
    {
        SceneManager.LoadScene("Level4");
    }
}
