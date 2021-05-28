using System;
using UnityEngine;

public class PlayerPhysics : Singleton<PlayerPhysics>,IGameEventObserver
{
    public Rigidbody rb;
    //condition variables to check if is stopping or if it's in air
    public bool isInAir;
    public bool isBreaking;

    public Vector3 ballDirection;
    private float inputAxisValue;
    public float moveForce;
    public float jumpForce;

    public void EnableObjectsPhysics()
    {
        //Set kinematic to false
    }
    public void DisableObjectPhysics()
    {
        rb.isKinematic = true;
    }

    //Add a force to the ball
    //In the specified direction and multiply it by the Axis-Value of the joystick * speed
    public void AddMovementToBall() 
    {
        rb.AddForce(ballDirection * moveForce * Time.fixedDeltaTime, ForceMode.Force);
    }
    public void BreakMove()
    {
        var horizontalVeocity = new Vector3(rb.velocity.x, -Physics.gravity.y, rb.velocity.z);
        if (horizontalVeocity.magnitude >= 1)
        {
            rb.AddForce(-horizontalVeocity * moveForce / 2.5f * Time.fixedDeltaTime, ForceMode.Force);
        }
    }   
    public void Jump()
    {
        if(!isInAir)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.Lose:
                DisableObjectPhysics();
                break;
            case EventName.StartBreaking:
                isBreaking = true;
                break;
            case EventName.EndBreaking:
                isBreaking = false;
                break;
        }
    }

    public void FixedUpdate()
    {
        if(isInAir == false)
        {
            AddMovementToBall();
        }
        if(isInAir == true)
        {
            if(isBreaking == true)
            {
                BreakMove();
            }
        }
        if(isBreaking == true)
        {
            BreakMove();
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

