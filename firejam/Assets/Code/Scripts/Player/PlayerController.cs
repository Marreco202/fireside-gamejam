using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    enum SpeedLevel
    {
        Low, Medium, High
    }

    private void KeepForward(bool enable, SpeedLevel speedLevel)
    {
        int speed;
        if (keep == true) 
        {
            switch(speedLevel)
            {
                case SpeedLevel.Low:
                speed = 10f;
                break;

                case SpeedLevel.Medium:
                speed = 20f;
                break;

                case SpeedLevel.High:
                speed = 30f;
                break;
            }
            GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * speed);
        }
    } 

    // Start is called before the first frame update
    void Start()
    {
        // define speed level

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
