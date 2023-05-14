using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start() 
    {
    
    }

    public void pressedQuitButton(){
        print("ANTES DE SAIR DO JOGO...");
        Application.Quit();
        print("DEPOIS DE SAIR DO JOGO...");
    }

}
