using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadModel : MonoBehaviour
{
    public Mesh shipMesh;
    // Start is called before the first frame update
    void Start()
    {
        Mesh shipMesh = Resources.Load("SondaJuno") as Mesh;
        GameObject playerObject = GameObject.Find("Player");
        playerObject = Instantiate(Resources.Load("SondaJuno", typeof(GameObject))) as GameObject;
        //playerObject.GetComponent<MeshFilter>().mesh = shipMesh; 
    }
}
