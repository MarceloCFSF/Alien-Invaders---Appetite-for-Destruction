using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //para controlar as cenas
using UnityEngine.UI;

public class MenuPrincipalManager : MonoBehaviour
{
    //variável para armazenar o nome da cena para localizá-la posteriormente
    [SerializeField] private string nomeLevelJogo;
    [SerializeField] private string nomeLevelJogo1;
    //variável para ativar/desativar menu
    [SerializeField] private GameObject MenuPrincipal;
    [SerializeField] private GameObject Opcoes;
    [SerializeField] private GameObject Level;
    //[SerializeField] torna visível no inspetor (indice)


    //método que será acionado quando o botão jogar for pressionado
    //é criado método público para aparecer no button
    public void Jogar()
    {
        //SceneManager.LoadScene("SampleScene"); não é muito adequado, pois se mudar o nome da cena tem que alterar o "nome" de novo
        SceneManager.LoadScene(nomeLevelJogo);
    }

    //método que será acionado quando o botão level for pressionado
    public void AbrirLevel()
    {
        SceneManager.LoadScene(nomeLevelJogo1);
    }

    //método que será acionado quando o botão opções for pressionado
    public void AbrirOpcoes()
    {
        //desativa o menu principal ao abrir opções
        MenuPrincipal.SetActive(false);
        //ativa as opções
        Opcoes.SetActive(true);
    }

    //método que será acionado quando o botão retornar for pressionado
    public void FecharOpcoes()
    {
        //ativa o menu principal ao fechar opções
        MenuPrincipal.SetActive(true);
        //desativa as opções
        Opcoes.SetActive(false);
    }

    //método que será acionado quando o botão sair for pressionado
    public void SairJogo()
    {
        //Ao jogar através do Editor Unity
        //para a aplicação ao clicar
        UnityEditor.EditorApplication.isPlaying = false;
        //apresentará uma mensagem de feedback, pois o método quit não funciona sem estar sendo compilado (.exe), não funciona no editor
        Debug.Log("Sair do Jogo");
        //fecha o jogo (.exe) 
        //Application.Quit(); *descomentar ao terminar o jogo e comentar a anterior
    }

}
