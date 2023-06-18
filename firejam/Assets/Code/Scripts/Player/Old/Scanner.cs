using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scanner : MonoBehaviour
{
    // Start is called before the first frame update
    Mesh mesh;
    MeshRenderer meshRenderer;

    [SerializeField] float maxHorizontalRange = 15f; // not negative because the initial position of the player test
    [SerializeField] float minHorizontalRange = -15f;

    GameObject playerObject;
    public Material material;
    ScannerObject scannerInstance = ScannerObject.getInstance();
    PlayerBehavior playerBehavior;
    public Material newMaterial;
    Rigidbody scannerRb;
    GameObject scannerObject;
    Vector3 scannerInitialPosition;

    float dynamicScannerPositionZ;

    void initObject()
    {
        playerObject = GameObject.Find("Player"); // This allows to find player object (givin the name) created through UI hierarchy
        //Debug.Log("Player speed: " + playerObject);
        scannerObject = GameObject.Find("Scanner");
        //scannerInstance.createConePolygon(scannerObject, material); //-93.357f

        // Setup Position and rotation
        //scannerInitialPosition = new Vector3(24.9f, 2.52f, 3.3f);
        scannerInitialPosition = new Vector3(0f, 0f, 3f);
        Vector3 objectSize = getGameObjectSize(playerObject); 

        scannerObject.transform.localRotation = Quaternion.Euler(0f, 0, 0);
        scannerObject.transform.localPosition = new Vector3(0f, 0f, scannerInitialPosition[2]);
    }

    private Vector3 getGameObjectSize(GameObject gameObject)
    {
        MeshRenderer renderer;
        Vector3 size;
        renderer = gameObject.GetComponent<MeshRenderer>();
        size = renderer.bounds.size;
        return size;
    }

    void Start()
    {
        initObject();
    }

    // Update is called once per frame
    void Update()
    {
        dynamicScannerPositionZ = (scannerInitialPosition[2] + playerObject.transform.position.z) + 10;
        scannerObject.transform.localPosition = new Vector3(playerObject.transform.position.x, playerObject.transform.position.y, dynamicScannerPositionZ);
        playerBehavior = playerObject.GetComponent<PlayerBehavior>();
        float clampMousePosX = Mathf.Clamp(playerBehavior.mousePos.x, minHorizontalRange, maxHorizontalRange);
        scannerObject.transform.localRotation = Quaternion.Euler(0f, clampMousePosX, 0);
        Vector3 playerObjectPoint = playerObject.transform.position + playerObject.transform.forward * 8f;
        scannerObject.transform.localPosition = new Vector3(playerObjectPoint[0], playerObject.transform.position.y, dynamicScannerPositionZ);
    }

    private void FixedUpdate()
    {
        // Always forward
        scannerRb = scannerObject.GetComponent<Rigidbody>();
        scannerRb.AddForce(transform.forward * Time.deltaTime * 10f);
    }
}
