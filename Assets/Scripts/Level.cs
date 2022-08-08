using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    //variável para armazenar o nome da cena para localizá-la posteriormente
    [SerializeField] private string nomeLevelJogo;
    //variável para ativar/desativar menu
    [SerializeField] private GameObject Level1;

    public void AbrirLevel1()
    {
        SceneManager.LoadScene(nomeLevelJogo);
    }

    

}
