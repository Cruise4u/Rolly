using System;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public Rigidbody rb;
    public ForceMode forceMode;
    public ForceMode jumpMode;

    public bool isInAir;
    public bool isBreaking;
    public float moveForce;
    public float jumpForce;

    public Action<Vector3,float> someaction;


    //Activate the ball physics..
    public void ActivatePhysics()
    {
        rb.isKinematic = false;
    }

    //Or deactivates it..
    public void DeactivatePhysics()
    {
        rb.isKinematic = true;
    }

    //Add a force of [ForceMode] to the ball
    //To the specified direction and multiply it by the Axis-Value of the joystick
    //And Multiply it again by the speed of the object
    public void Move(Vector3 direction, float axisValue)
    {
        rb.AddForce(direction * axisValue * moveForce * Time.fixedDeltaTime, forceMode);
    }

    //Add a force of [ForceMode] to the object
    //To the specified direction and multiply it by a force
    public void Jump()
    {
        if(!isInAir)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, jumpMode);
        }
    }
    
    public void BreakMove()
    {
        if(rb.velocity.magnitude > 1)
        {
            rb.AddForce(-rb.velocity * moveForce/3 * Time.fixedDeltaTime , forceMode);
            Debug.Log("Breaking!");
        }
    }

    Action OnInputTriggered;

    public void FixedUpdate()
    {
        var inputFunc = FindObjectOfType<PlayerController>().OnPassingInformation;
        if(inputFunc != null)
        {
            inputFunc = (direction, speed) => Move(direction, speed);
        }
    }

    //Check if the ball is either in the air or in the ground
    public void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            isInAir = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Ground"))
        {
            isInAir = true;
        }
    }
}

