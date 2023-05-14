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

    public void createConePolygon(GameObject gameObject, Material material) 
    {
        //gameObject = createGameObject();
        //Debug.Log(this.GetType().Name + ": " + "Creating...");
        gameObject.AddComponent<MeshFilter>();
        meshRenderer = gameObject.AddComponent<MeshRenderer>();
        meshRenderer.material = material;
        mesh = new Mesh();
        gameObject.GetComponent<MeshFilter>().mesh = mesh;

        vertices = new List<Vector3>();
        position = new Vector3();

        angleAmount = 2 * Mathf.PI / segments;
        angle = 0.0f;

        // centro da base do cone
        position.x = 0.0f;
        position.y = height;
        position.z = 0.0f;
        vertices.Add(new Vector3(position.x, position.y, position.z));

        //
        position.y = 0.0f;
        vertices.Add(new Vector3(position.x, position.y, position.z));

        for (int i = 0; i < segments; i++)
        {
            position.x = radius * Mathf.Sin(angle);
            position.z = radius * Mathf.Cos(angle);

            vertices.Add(new Vector3(position.x, position.y, position.z));

            angle -= angleAmount;
        }

        mesh.vertices = vertices.ToArray();

        triangles = new List<int>();

        for (int i = 2; i < segments + 1; i++)
        {
            triangles.Add(0);
            triangles.Add(i+1);
            triangles.Add(i);
        }

        triangles.Add(0);
        triangles.Add(2);
        triangles.Add(segments +1);

        mesh.triangles = triangles.ToArray();

        Debug.Log(this.GetType().Name + ": " + "Finish...");
    }
}
