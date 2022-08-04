using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class SoundManager : MonoBehaviour
{
    public AudioSource AudioSource;
    [SerializeField] Slider SliderVolume;

    // Start is called before the first frame update
    void Start()
    {
     
    }

    
    public void ChangeVolume()
    {
        AudioListener.volume = SliderVolume.value;
        Save();
    }
        
    private void Load()
    {
        SliderVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        
    }
        
}
