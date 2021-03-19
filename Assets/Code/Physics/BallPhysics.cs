using System;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    public ForceMode forceMode;
    public ForceMode jumpMode;

    public Rigidbody rb;
    public bool isInAir;
    public float moveForce;
    public float jumpForce;




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
            rb.AddForce(-rb.velocity * moveForce * Time.fixedDeltaTime * 0.5f, forceMode);
            Debug.Log("Breaking!");
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

