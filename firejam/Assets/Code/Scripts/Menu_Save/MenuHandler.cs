using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() 
    {
    
    }


    public void pressedPlayButton(){
        SceneManager.LoadScene(1); //0 = main menu ; 1 = SampleScene 
        print("Entrei #O_O#");
    }

    public void pressedQuitButton(){
        print("ANTES DE SAIR DO JOGO...");
        Application.Quit();
        print("DEPOIS DE SAIR DO JOGO...");
    }

}
