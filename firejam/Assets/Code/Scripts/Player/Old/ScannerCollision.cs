using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerCollision : MonoBehaviour
{
    //public int currentProgress;
    //public int maxProgress = 100;
    //public int minProgress = 0;
    public Material newMaterial;
    public ScannerProgressBar progressBarInstance = ScannerProgressBar.getInstance();

    private GameObject playerObject;
    public GameObject progressBarPrefab;
    public GameObject progressBar;

    TestAudio audio_src;

    void Start()
    {
        audio_src = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<TestAudio>(); //have acess to all the publics methods of that script
        //
    }

    void Update()
    {
        audio_src.playAudioOnKey();
    }

    private void initProgressBar() 
    {
        float screenHeight = Screen.height;
        playerObject = GameObject.Find("Player"); 
        progressBar = Instantiate(progressBarPrefab, new Vector2(playerObject.transform.position.x, screenHeight), Quaternion.identity); // instantiate an prefab
    
        // Progress Bar Mono Behavior Instance
        //progressBarInstance = progressBarPrefab.GetComponent<ScannerProgressBar>();

        ScannerProgressBar.progress = 0;
        //progressBarInstance.SetMaxProgressStatus(maxProgress);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "MeteorStatic") {
            print(">>>>>> COLLISION!!!!!!!! <<<<<<");   
            initProgressBar();
            audio_src.playAudio((int) audioNames.Escaneando);

            GetComponent<MeshRenderer>().material = newMaterial;
            //currentProgress += 5;
            ScannerProgressBar.progress += 5;

            //progressBarInstance.SetProgress(currentProgress);
        }

        else if(other.GetComponent<Collider>().tag == "TestAudioTag") { //comment this before build
            audio_src.playAudio((int) audioNames.clip);
        }
    }

    //private void OnTriggerStay(Collider other)

}
