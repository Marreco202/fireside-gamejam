// We are using the old input system
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float acceleration = 1.0f;
    float maxSpeed = 60.0f;  
    private float curSpeed = 0.0f;


    [SerializeField] float speed = 15f;
    [SerializeField] float maxHorizontalRange = 30f;
    [SerializeField] float minHorizontalRange = 20f;
    [SerializeField] Vector3 initialPlayerPos = new Vector3(24.9f, 2.52f, 2.5f);

    void Start()
    {
        transform.localPosition = initialPlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        ManualPlayerMoviment();
    }

    void ManualPlayerMoviment() 
    {
        float posX = Input.GetAxis("Horizontal");
        //float posY = Input.GetAxis("Vertical");
        //Debug.Log(posY);
        Debug.Log(posX);

        float xOffset = posX * Time.deltaTime * speed;
        float rawPosX = transform.localPosition.x + xOffset;

        float clampPosX = Mathf.Clamp(rawPosX, minHorizontalRange, maxHorizontalRange); // limit axis x of moviment

        transform.localPosition = new Vector3(clampPosX, transform.localPosition.y, transform.localPosition.z);
    }
 
    void AutomaticPlayerMoviment() 
    {
 
        transform.Translate (Vector3.forward*curSpeed * Time.deltaTime);
    
        curSpeed += acceleration * Time.deltaTime;
    
        if (curSpeed > maxSpeed)
            curSpeed = maxSpeed;
    }
}