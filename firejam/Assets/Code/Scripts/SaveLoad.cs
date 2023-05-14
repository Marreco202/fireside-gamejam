using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    // Start is called before the first frame update
    
    //If the tape was played, then tape_x == 1, else tape_x == 0
    int tape_1, tape_2, tape_3, tape_4, tape_5, tape_6; //add more tapes here if necessary
    float volume;
    int is_windowed;
    int resolution_x, resolution_y;

    void Start()
    {
        
    }

    void Save()
    {
        PlayerPrefs.SetInt("tape_1",tape_1);
        PlayerPrefs.SetInt("tape_2",tape_2);
        PlayerPrefs.SetInt("tape_3",tape_3);
        PlayerPrefs.SetInt("tape_4",tape_4);
        PlayerPrefs.SetInt("tape_5",tape_5);
        PlayerPrefs.SetInt("tape_6",tape_6);
        PlayerPrefs.SetFloat("volume",volume);
        PlayerPrefs.SetInt("is_windowed",is_windowed);
        PlayerPrefs.SetInt("resolution_x",resolution_x);
        PlayerPrefs.SetInt("resolution_y",resolution_y);
    }

    void Load()
    {
        tape_1 = PlayerPrefs.GetInt("tape_1");
        tape_2 = PlayerPrefs.GetInt("tape_2");
        tape_3 = PlayerPrefs.GetInt("tape_3");
        tape_4 = PlayerPrefs.GetInt("tape_4");
        tape_5 = PlayerPrefs.GetInt("tape_5");
        tape_6 = PlayerPrefs.GetInt("tape_6");
        volume = PlayerPrefs.GetFloat("volume");
        is_windowed = PlayerPrefs.GetInt("is_windowed");
        resolution_x = PlayerPrefs.GetInt("resolution_x");
        resolution_y = PlayerPrefs.GetInt("resolution_y");
        changeWindowMode(); //comment this if the game crashes
    }

    void changeResolution()
    {
        Screen.SetResolution(resolution_x,resolution_y,true);
    }

    void changeWindowMode()
    {
        if(is_windowed == 1){ //fvck u c#
            Screen.fullScreen = !Screen.fullScreen; //idk if this is right. maybe can crash
            changeResolution();
        }
    }

    void resetTapes()
    { //when a player quits midgame, we don't wanna save the tapes that he got.
        PlayerPrefs.SetInt("tape_1",0);
        PlayerPrefs.SetInt("tape_2",0);
        PlayerPrefs.SetInt("tape_3",0);
        PlayerPrefs.SetInt("tape_4",0);
        PlayerPrefs.SetInt("tape_5",0);
        PlayerPrefs.SetInt("tape_6",0);

    }
}
