using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ScannerObject
{

    Mesh mesh;
    MeshRenderer meshRenderer;

    List<Vector3> vertices;
    List<int> triangles;

    //public Material material;
    //GameObject gameObject;

    public float height = 15.0f;
    private float radius = 5.0f;
    private int segments = 5;

    Vector3 position;

    float angle = 90.0f; // default 0.0f
    float angleAmount = 0.0f;

    private static ScannerObject instance;

    private ScannerObject() { }

    public static ScannerObject getInstance()
    {
        if (instance == null) 
        {
            instance = new ScannerObject();
        }
        return instance;
    }
    
    // Start is called before the first frame update
}
