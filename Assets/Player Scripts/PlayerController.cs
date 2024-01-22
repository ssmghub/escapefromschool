using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    float verticalVelocity = 0;
    public float jumpH = 3.0f; 

    public float moveMultiplier = 5.0f;
    public float mouseSensitivity = 5.0f;
    float y = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (Cursor.lockState == CursorLockMode.Locked)
                Cursor.lockState = CursorLockMode.Confined;
            else
                Cursor.lockState = CursorLockMode.Locked;
        }

        float rotation = Input.GetAxis("Mouse X") * mouseSensitivity;
        transform.Rotate(0, rotation, 0); //x,y,z

        float updown = Input.GetAxis("Mouse Y") * mouseSensitivity;
        if(y + updown >= 80 || y + updown <= -85)
        {
            updown = 0; 
        }

        Camera.main.transform.Rotate(-updown, 0, 0);
        y += updown;

        float forwardSpeed = Input.GetAxis("Vertical");
        float lateralSpeed = Input.GetAxis("Horizontal");

        verticalVelocity += Physics.gravity.y * Time.deltaTime; 

        CharacterController characterController = GetComponent<CharacterController>();

        if(Input.GetButton("Jump") && characterController.isGrounded)
        {
            verticalVelocity = jumpH; 
        }

        Vector3 speed = new Vector3(lateralSpeed * moveMultiplier,verticalVelocity,forwardSpeed * moveMultiplier);
        speed = transform.rotation * speed; 
        characterController.Move(speed * Time.deltaTime); 

        // fire(); // Move to hand actions scripts
        
    }


}