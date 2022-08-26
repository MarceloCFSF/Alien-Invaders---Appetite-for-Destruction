using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script para aplicar o personagem selecionado no jogo
public class GetMainCharacter : MonoBehaviour
{
    public Sprite green, red, dark, armor, blue;
    private SpriteRenderer mySprite;
    private readonly string selectedCharacter = "SelectedCharacter";


    void Awake()
    {
        mySprite = this.GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        int getCharacter;

        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        switch (getCharacter)
        {
            case 1:
                mySprite.sprite = red;
                break;
            case 2:
                mySprite.sprite = dark;
                break;
            case 3:
                mySprite.sprite = armor;
                break;
            case 4:
                mySprite.sprite = blue;
                break;
            case 5:
                mySprite.sprite = green;
                break;
            default:
                mySprite.sprite = green;
                break;
        }
    }


}
