using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    float acceleration = 1.0f;
    float maxSpeed = 60.0f;  
    private float curSpeed = 0.0f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoviment();
    }

    void PlayerMoviment()
    {
        //float posX = Input.GetKey("w") * Time.deltaTime * moveSpeed;
        ///float posZ = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        //transform.Translate(posX, 0, posZ);
        PlayerMoviment1();
    }
 
    void PlayerMoviment1 () {
 
        transform.Translate (Vector3.forward*curSpeed * Time.deltaTime);
    
        curSpeed += acceleration * Time.deltaTime;
    
        if (curSpeed > maxSpeed)
            curSpeed = maxSpeed;
    }
}