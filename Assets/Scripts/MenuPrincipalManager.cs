using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuPrincipalManager : MonoBehaviour
{
    
    [SerializeField] private string nomeLevelJogo;
    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject Opcoes;
    [SerializeField] private GameObject Level;
    


    
    public void Jogar()
    {
        
        SceneManager.LoadScene(nomeLevelJogo);
    }

    
    public void AbrirLevel()
    {
        
        MenuPrincipal.SetActive(false);
        
    }

    
    public void AbrirOpcoes()
    {
        
        MenuPrincipal.SetActive(false);
        
        Opcoes.SetActive(true);
    }

    
    public void FecharOpcoes()
    {
        
        MenuPrincipal.SetActive(true);
        
        Opcoes.SetActive(false);
    }

    
    public void SairJogo()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit(); 
        #endif
        Debug.Log("Sair do Jogo");
    }

}
