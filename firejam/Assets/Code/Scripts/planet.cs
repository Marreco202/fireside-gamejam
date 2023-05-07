using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planet : MonoBehaviour
{
    // Start is called before the first frame update

    public float velocity = 1.1f;
    public Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(-transform.forward * 25f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        Vector3 position = new Vector3(x,y,0);
        
        // Vector3 dir = new Vector3(x,0,y) * velocity;

        //rb.MovePosition(transform.position * velocity *Time.deltaTime);
        

    }
}
