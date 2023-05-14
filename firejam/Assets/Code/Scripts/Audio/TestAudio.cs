using System.Collections;
using System.Collections.Generic;
using UnityEngine;

   public enum audioNames 
    {
        Vacuo,
        Sucesso,
        PerdeuLore,
        Impacto,
        FudeuNave,
        Escaneando,
        AlphaFaster,
        AlphaFast,
        clip
    }

public class TestAudio : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;
    public AudioClip Vacuo;
    public AudioClip Sucesso;
    public AudioClip PerdeuLore;
    public AudioClip Impacto;
    public AudioClip FudeuNave;
    public AudioClip Escaneando;
    public AudioClip AlphaFaster;
    public AudioClip AlphaFast;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playAudioOnKey(); 
    }
    
    public void playAudio(int name)
    { //method used for playing all the SFX of the game
        switch(name)
        {
            case 0: //enum number
                src.PlayOneShot(Vacuo); //name of the file to be played
                break;
            case 1:
                src.PlayOneShot(Sucesso);
                break;
            case 2:
                src.PlayOneShot(PerdeuLore);
                break;
            case 3:
                src.PlayOneShot(Impacto);
                break;
            case 4:
                src.PlayOneShot(FudeuNave);
                break;
            case 5:
                src.PlayOneShot(Escaneando);
                break;
            case 6:
                src.PlayOneShot(AlphaFaster);
                break;
            case 7:
                src.PlayOneShot(AlphaFast);
                break;
            case 8:
                src.PlayOneShot(clip);
                break;

        }
    }

       public void playAudioOnKey()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            playAudio((int) audioNames.clip); //this is working, therefore the playAudio is working as well
        }  
    }

}
