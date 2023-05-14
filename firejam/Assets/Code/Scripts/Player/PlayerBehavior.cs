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
    [SerializeField] float maxHorizontalRange = 15f;
    [SerializeField] float minHorizontalRange = -15f;
    [SerializeField] Vector3 initialPlayerPos = new Vector3(0f, 0f, 0f);

    // Pitch
    [SerializeField] float positionPitchScreenBased = -5f;
    [SerializeField] float controlPitchScreenBased = -5f;

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

        // Contante Rotation

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
        // PITCH = y axis in a Vector3
        float pitchPositionBased = transform.localPosition.y * positionPitchScreenBased;
        float pitchControlBased = posY * controlPitchScreenBased;
        float pitch = pitchPositionBased + pitchControlBased;
        float roll = 0f;
        
        MouseYawMovement(pitch, roll);
    }

    private void MouseYawMovement(float pitch, float roll) 
    {
        mousePos.x += Input.GetAxis("Mouse X") * mouseSensitivity;
        float clampMousePosX = Mathf.Clamp(mousePos.x, minHorizontalRange, maxHorizontalRange);
        transform.localRotation = Quaternion.Euler(pitch, clampMousePosX, roll);
    }

    void localMovHorizontalMechanic() 
    {
        posX = Input.GetAxis("Horizontal");
        posY = Input.GetAxis("Vertical");

        float xOffset = posX * Time.deltaTime * speed;
        float rawPosX = transform.localPosition.x + xOffset;

        float clampPosX = Mathf.Clamp(rawPosX, minHorizontalRange, maxHorizontalRange); // Limit axis x of moviment

        transform.localPosition = new Vector3(clampPosX, transform.localPosition.y, transform.localPosition.z);
    }
}