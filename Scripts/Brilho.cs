using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brilho : MonoBehaviour
{
    public Slider brilho;


    //método para alterar a sensibilidade
    public void AlterarBrilho()
    {
        RenderSettings.ambientLight = Color.Lerp(Color.black, Color.white, brilho.value);
        print("Brilho = " + brilho.value);
    }

}
