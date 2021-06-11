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
    public int numberJumps;

    public Vector3 ballDirection;
    private float inputAxisValue;
    public float moveForce;
    public float jumpForce;
    #endregion
    public void AddMovementToBall() 
    {
        rb.AddForce(ballDirection * moveForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }
    public void BreakMove()
    {
        var horizontalVeocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVeocity.magnitude >= 1)
        {
            rb.AddForce(-horizontalVeocity * (moveForce / 1.5f) * Time.fixedDeltaTime, ForceMode.Force);
        }
    }   
    public void Jump()
    {
        if(!isInAir)
        {
            if (numberJumps > 0)
            {
                var jumpVector = Vector3.up * jumpForce * Time.fixedDeltaTime;
                rb.AddForce(jumpVector, ForceMode.Impulse);
                SoundController.Instance.PlaySound("JumpSound");
            }
        }
    }
    public void DisablePhysics()
    {
        isPhysicsBodyActive = false;
        rb.isKinematic = true;
    }
    public void EnablePhysics()
    {
        isPhysicsBodyActive = true;
        rb.isKinematic = false;
    }
    public void Notified(EventName eventName)
    {
        switch (eventName)
        {

            case EventName.Tutorial:
                EnablePhysics();
                break;
            case EventName.Win:
                DisablePhysics();
                break;
            case EventName.Lose:
                DisablePhysics();
                break;
            case EventName.EnterLevel:
                DisablePhysics();
                numberJumps = 1;
                break;
            case EventName.StartLevel:
                EnablePhysics();
                break;
        }
    }
    public void FixedUpdate()
    {
        if(isPhysicsBodyActive != false)
        {
            AddMovementToBall();
        }
    }


    //Check if the ball is either in the air or in the ground
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            isInAir = false;
            numberJumps = 1;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            isInAir = true;
            numberJumps = 0;
        }
    }
}

