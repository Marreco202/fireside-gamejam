using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour
{
    public GameObject propPrefab;
    GroundSpawner groundSpawner;

    // Start is called before the first frame update
    void Start()
    {
        groundSpawner = GameObject.FindObjectOfType<GroundSpawner>();
        SpawnProps();
    }

    /// <summary>
    /// OnTriggerExit is called when the Collider other has stopped touching the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerExit(Collider other)
    {
        groundSpawner.spawnGroundPiece();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnProps() 
    {
        int spawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(spawnIndex).transform;

        // Instantiate prefab and spawn at position
        Instantiate(propPrefab, spawnPoint.position, Quaternion.identity, transform);


    }
}
