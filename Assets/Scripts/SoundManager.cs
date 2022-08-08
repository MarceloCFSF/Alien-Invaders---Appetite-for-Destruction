using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //acessar elementos UI pelo código

public class SoundManager : MonoBehaviour
{
    public Slider sliderVolume;
    //public AudioSource AudioSource;
    //[SerializeField] Slider SliderVolume;

    // Start is called before the first frame update
    /*void Start()
    {
        if(!PlayerPrefs.Haskey("musicVolume"))
        {
            PlayerPrefs.SetFloat("musicVolume", 1);
           Load();
        }
        else
        {
            Load();
        }
    }*/



    //função para alterar o volume
    public void ChangeVolume()
    {
        AudioListener.volume = sliderVolume.value;
        print("Volume = " + sliderVolume.value);
    }



    //private void Save()
    //{
    //PlayerPrefs - armazena as preferencias do usuário nas sessões do jogo
    // "musicVolume" = keyname
    //PlayerPrefs.setFloat("musicVolume", sliderVolume.value);
    //}

}
