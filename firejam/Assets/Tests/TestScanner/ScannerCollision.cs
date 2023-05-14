using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerCollision : MonoBehaviour
{

    public Material newMaterial;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().name == "MeteorStatic") {

            GetComponent<MeshRenderer>().material = newMaterial;
        }
    }

}
