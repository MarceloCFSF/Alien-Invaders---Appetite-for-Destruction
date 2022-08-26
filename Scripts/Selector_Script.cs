using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selector_Script : MonoBehaviour
{
    public GameObject Green;
    public GameObject Red;
    public GameObject Dark;
    public GameObject Armor;
    public GameObject Blue;
    private Vector3 CharacterPosition;
    private Vector3 OffScreen;
    private int CharacterInter = 1;
    private SpriteRenderer GreenRenderer, RedRenderer, DarkRenderer, ArmorRenderer, BlueRenderer;
    private readonly string selectedCharacter = "SelectedCharacter";


    private void Awake()
    {
        CharacterPosition = Green.transform.position;
        OffScreen = Red.transform.position;
        GreenRenderer = Green.GetComponent<SpriteRenderer>();
        RedRenderer = Red.GetComponent<SpriteRenderer>();
        DarkRenderer = Dark.GetComponent<SpriteRenderer>();
        ArmorRenderer = Armor.GetComponent<SpriteRenderer>();
        BlueRenderer = Blue.GetComponent<SpriteRenderer>();
    }

    //função para o botão next
    public void Next()
    {
        switch(CharacterInter)
        {
            //Red
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                GreenRenderer.enabled = false;
                Green.transform.position = OffScreen;
                Red.transform.position = CharacterPosition;
                RedRenderer.enabled = true;
                CharacterInter++;
                break;
            //Dark
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                RedRenderer.enabled = false;
                Red.transform.position = OffScreen;
                Dark.transform.position = CharacterPosition;
                DarkRenderer.enabled = true;
                CharacterInter++;
                break;
            //Armor
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                DarkRenderer.enabled = false;
                Dark.transform.position = OffScreen;
                Armor.transform.position = CharacterPosition;
                ArmorRenderer.enabled = true;
                CharacterInter++;
                break;
            //Blue
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                ArmorRenderer.enabled = false;
                Armor.transform.position = OffScreen;
                Blue.transform.position = CharacterPosition;
                BlueRenderer.enabled = true;
                CharacterInter++;
                break;
            //Green
            case 5:
                PlayerPrefs.SetInt(selectedCharacter, 5);
                BlueRenderer.enabled = false;
                Blue.transform.position = OffScreen;
                Green.transform.position = CharacterPosition;
                GreenRenderer.enabled = true;
                CharacterInter++;
                ResetInt();
                break;
            default:
                ResetInt();
                break;
        }
    }

    //função para o botão previous
    public void Previous()
    {
        //ao clicar no BtNext ele enconde o anterior e apresenta o proximo
        switch (CharacterInter)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 3);
                GreenRenderer.enabled = false;
                Green.transform.position = OffScreen;
                Blue.transform.position = CharacterPosition;
                BlueRenderer.enabled = true;
                CharacterInter--;
                ResetInt();
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 4);
                RedRenderer.enabled = false;
                Red.transform.position = OffScreen;
                Green.transform.position = CharacterPosition;
                GreenRenderer.enabled = true;
                CharacterInter--;
                break;
            case 3:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                DarkRenderer.enabled = false;
                Dark.transform.position = OffScreen;
                Red.transform.position = CharacterPosition;
                RedRenderer.enabled = true;
                CharacterInter--;
                break;
            case 4:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                ArmorRenderer.enabled = false;
                Armor.transform.position = OffScreen;
                Dark.transform.position = CharacterPosition;
                DarkRenderer.enabled = true;
                CharacterInter--;
                break;
            case 5:
                PlayerPrefs.SetInt(selectedCharacter, 5);
                BlueRenderer.enabled = false;
                Blue.transform.position = OffScreen;
                Armor.transform.position = CharacterPosition;
                ArmorRenderer.enabled = true;
                CharacterInter--;
                break;
            default:
                ResetInt();
                break;
        }
    }

    //função para recomeçar ao chegar no último personagem
    private void ResetInt()
    {
        if(CharacterInter >=5)
        {
            CharacterInter = 1;
        }
        else
        {
            CharacterInter = 5;
        }

    }

    public void ChangeScene()
    {
        SceneManager.LoadScene("Level");
    }
}
