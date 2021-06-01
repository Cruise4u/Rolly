using System;
using UnityEngine;

public class PlayerPhysics : Singleton<PlayerPhysics>,IEventObserver
{
    #region Class Field Members
    public Rigidbody rb;
    public bool isInAir;
    public bool isBreaking;
    public bool isJumping;
    public bool isPhysicsBodyActive;


    public Vector3 ballDirection;
    private float inputAxisValue;
    public float moveForce;
    public float jumpForce;
    #endregion
    public void AddMovementToBall() 
    {
        rb.AddForce(ballDirection * moveForce * Time.fixedDeltaTime, ForceMode.Force);
    }
    public void BreakMove()
    {
        var horizontalVeocity = new Vector3(rb.velocity.x, -Physics.gravity.y, rb.velocity.z);
        if (horizontalVeocity.magnitude >= 1)
        {
            rb.AddForce(-horizontalVeocity * (moveForce / 2.5f) * Time.fixedDeltaTime, ForceMode.Force);
        }
    }   
    public void Jump()
    {
        if(!isInAir)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
        }
    }
    public void DisablePhysics()
    {
        isPhysicsBodyActive = false;
    }
    public void EnablePhysics()
    {
        isPhysicsBodyActive = true;
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {
            case EventName.EnterLevel:
                DisablePhysics();
                break;
            case EventName.StartLevel:
                EnablePhysics();
                break;
            case EventName.Lose:
                DisablePhysics();
                break;
            case EventName.StartBreaking:
                isBreaking = true;
                break;
            case EventName.EndBreaking:
                isBreaking = false;
                break;
            case EventName.Win:
                DisablePhysics();
                break;
        }
    }
    public void FixedUpdate()
    {
        if(isPhysicsBodyActive != false)
        {
            if (isInAir == false)
            {
                AddMovementToBall();
            }
            if (isBreaking == true)
            {
                BreakMove();
            }
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

