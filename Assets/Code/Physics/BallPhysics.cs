using System;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    //References to other objects
    public GameManager gameManager;
    public PlayerController playerController;
    public Rigidbody rb;

    //condition variables to check if is stopping or if it's in air
    public bool isInAir;
    public bool isBreaking;

    public Vector3 ballDirection;
    public float inputAxisValue;
    public float moveForce;
    public float jumpForce;
    public ForceMode forceMode;
    public ForceMode jumpMode;


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
    public void AddMovementToBall() 
    {
        rb.AddForce(ballDirection * moveForce * Time.fixedDeltaTime, forceMode);
    }

    //Add a force of [ForceMode] to the object
    //To the specified direction and multiply it by a force
    public void Jump()
    {
        if (!isInAir)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, jumpMode);
        }
    }

    public void BreakMove()
    {
        if (rb.velocity.magnitude > 1)
        {
            rb.AddForce(-rb.velocity * moveForce / 2 * Time.fixedDeltaTime, forceMode);
            Debug.Log("Breaking!");
        }
    }

    public void FixedUpdate()
    {
        if(isInAir == false)
        {
            AddMovementToBall();
        }
    }

    //Check if the ball is either in the air or in the ground
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isInAir = false;
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isInAir = true;
        }
    }
}

