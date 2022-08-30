using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //acessar elementos UI pelo código

public class SoundManager : MonoBehaviour
{

    //variavel que já inicia o som ligado
    //private bool estadoSom = true;
    public Slider sliderVolume;
    //variavel para referencia ao audiosource da música de fundo
    /*[SerializeField] private AudioSource fundoMusical;
    [SerializeField] private Sprite somLigadoSprite;
    [SerializeField] private Sprite somDesligadoSprite;

    [SerializeField] private Image muteImage;*/

    //[SerializeField] Image soundOnIcon;
    //[SerializeField] Image soundOffIcon;
    //private bool muted = false;

    [SerializeField] private Sprite soundOnImage;
    [SerializeField] private Sprite soundOffImage;
    public Button button;
    private bool isOn = true;
    public AudioSource audioSource;


    //função para alterar o volume
    public void ChangeVolume()
    {
        AudioListener.volume = sliderVolume.value;
        print("Volume = " + sliderVolume.value);

        //float valorVolume = sliderVolume.value;

        //salva volume atual
        PlayerPrefs.SetFloat("sliderVolume", sliderVolume.value);
    }



    void Start()
    {

    }

    public void ButtonClicked()
    {
        if (isOn)
        {
            button.image.sprite = soundOffImage;
            isOn = false;
            audioSource.mute = true;
        }
        else
        {
            button.image.sprite = soundOnImage;
            isOn = true;
    
            audioSource.mute = false;
        }
    }



}

//função mude/unmute
//public void LigarDesligarSom()
/*{
    //caso o estado do som seja verdadeiro, ao clicar desliga
    estadoSom = !estadoSom;
    fundoMusical.enable = estadoSom;

    if (estadoSom)
    {
        muteImage.sprite = somLigadoSprite;
    }
    else
    {
        muteImage.sprite = somDesligadoSprite;
    }

}*/
