using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner : MonoBehaviour
{

    public GameObject groundPiece;
    Vector3 nextSpawnPoint;

    // Start is called before the first frame update

    public void spawnGroundPiece()
    {
        GameObject nextPointReference = Instantiate(groundPiece, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = nextPointReference.transform.GetChild(1).transform.position; // 1 beacuse the child that we want is the number 1 form the list hierarchy of groundspawner object
    }

    void Start()
    {
        // This variable defines how many points of spawn the scene has 
        int sceneSpawnerCount = 20;
        // Maybe its interessing put the function of delay 
        for (int i = 0; i < sceneSpawnerCount; i++) 
        {
            spawnGroundPiece();
        }
    }
}
