using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAudio : MonoBehaviour
{
    public AudioSource src;
    public AudioClip clip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //playAudioOnKey(); 
    }

    public void playAudioOnKey()
    {
        if(Input.GetKeyDown(KeyCode.R)){
            src.PlayOneShot(clip);
        }  
    }

    public void playAudio(){
        src.PlayOneShot(clip);
    }
}
