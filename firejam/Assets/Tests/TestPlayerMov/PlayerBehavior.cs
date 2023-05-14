// Caio Madeira
// We are using the old input system
// Rotation - Z: Roll, X: Pitch (Up and Down), Y: Yaw
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    //float acceleration = 1.0f;
    //float maxSpeed = 60.0f;  
    //private float curSpeed = 0.0f;
    private Rigidbody rb;

    [SerializeField] float speed = 15f;
    [SerializeField] float maxHorizontalRange = 15f; // not negative because the initial position of the player test
    [SerializeField] float minHorizontalRange = 5f;
    [SerializeField] Vector3 initialPlayerPos = new Vector3(24.9f, 2.52f, 2.5f);

    // Pitch
    [SerializeField] float positionPitchScreenBased = -2f;
    [SerializeField] float controlPitchScreenBased = -10f;

    // Yaw
    //[SerializeField] float positionRawScreenBased = -5f;
    //[SerializeField] float controlRawScreenBased = -10f;

    [SerializeField] float posX;
    [SerializeField] float posY;

    // Mouse
    [SerializeField] public Vector2 mousePos;
    [SerializeField] public float mouseSensitivity = .5f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.localPosition = initialPlayerPos;
    }

    // Update is called once per frame
    void Update()
    {
        localMovHorizontalMechanic();
        localMovRotationMechanic();
    }

    private void FixedUpdate() 
    {
        AlwaysForward(); // lead with physics so its recommended to be called in fixedUpdate()
    }

    void AlwaysForward()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * Time.deltaTime * 10f);   // The delta time is necessary because the player run fast and get 'flick' effect
    }

    // the player is rotating according to its own axis (local) and not according to the world
    void localMovRotationMechanic()
    {
        // PITCH
        float pitchPositionBased = transform.localPosition.y * positionPitchScreenBased;
        float pitchControlBased = posY * controlPitchScreenBased;
        float pitch = pitchPositionBased + pitchControlBased;

        // yaw - mechanic


        //float yaw = transform.localPosition.x * -5f;
        //float yaw = 0f;
        //Debug.Log(">>>>>>>>>>>>>>> YAM CALC:" + yaw);

        float roll = 0f;

        //StartCoroutine(MouseYawMovementDelay(pitch, roll, 0f));
        
        MouseYawMovement(pitch, roll);
        // transform.localRotation = Quaternion.Euler(pitch, clampMousePosX, roll); // Quaternion.Euler(pitch, raw, roll)
    }

    private void MouseYawMovement(float pitch, float roll) 
    {
        mousePos.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        float clampMousePosX = Mathf.Clamp(mousePos.x, -15, 15);
        transform.localRotation = Quaternion.Euler(pitch, clampMousePosX, roll);
    }

    private IEnumerator MouseYawMovementDelay(float pitch, float roll, float delay)
    {
        mousePos.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        float clampMousePosX = Mathf.Clamp(mousePos.x, -15, 15);
        yield return new WaitForSeconds(2f);
        transform.localRotation = Quaternion.Euler(pitch, clampMousePosX, roll);
    }

    void localMovHorizontalMechanic() 
    {
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        //Debug.Log(posX);

        float xOffset = posX * Time.deltaTime * speed;
        float rawPosX = transform.localPosition.x + xOffset;

        float clampPosX = Mathf.Clamp(rawPosX, minHorizontalRange, maxHorizontalRange); // Limit axis x of moviment

        transform.localPosition = new Vector3(clampPosX, transform.localPosition.y, transform.localPosition.z);
    }
 
    //void AutomaticPlayerMoviment() 
    //{
 
        //transform.Translate(Vector3.forward * curSpeed * Time.deltaTime);
    
        //curSpeed += acceleration * Time.deltaTime;
    
        //if (curSpeed > maxSpeed)
            //curSpeed = maxSpeed;
    //}
}