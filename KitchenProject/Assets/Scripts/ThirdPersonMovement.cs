using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
   

    public CharacterController controller;
    public Transform cam;

    public float speed = 6f;

    public float turnsmoothTime = 0.1f;

    public static bool AnimationStatus = false;

    float turnsmoothVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;                                                                           //hides the curson when game is activated 
    }

    void FixedUpdate()
    {
        float horizontal =Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            AnimationStatus = true;
            float Angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;                           // returns angle turned between y and x axis 
            float smoothangle = Mathf.SmoothDampAngle(transform.eulerAngles.y, Angle, ref turnsmoothVelocity, turnsmoothTime); // smooths outh the turning of the player model
            transform.rotation = Quaternion.Euler(0f, smoothangle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, Angle, 0f) * Vector3.forward;                                               //turns the model where the camera is facing 
            controller.Move(moveDir.normalized * speed * (Time.deltaTime));
        }
        else
        {
            AnimationStatus = false;
        }
        
            
    }
}
