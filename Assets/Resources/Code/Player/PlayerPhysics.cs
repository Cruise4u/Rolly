using System;
using UnityEngine;

public class PlayerPhysics : Singleton<PlayerPhysics>,IEventObserver
{
    #region Class Field Members
    public Rigidbody rb;
    public PhysicMaterial physicMaterial;
    public bool isInAir;
    public bool isBreaking;
    public bool isJumping;
    public bool isPhysicsBodyActive;
    public int numberJumps;

    public Vector3 ballVelocity;
    private float inputAxisValue;
    public float moveForce;
    public float jumpForce;
    #endregion

    public void Start()
    {
        PlayerController.Instance.inputDelegate += SetBallVelocity;
        PlayerController.Instance.jumpDelegate += JumpBall;
        PlayerTriggers.Instance.OnAirDelegate += SetBallOnAir;
        PlayerTriggers.Instance.OnGroundDelegate += SetBallOnGround;
    }

    public void SetBallVelocity(Vector3 velocity)
    {
        ballVelocity = velocity;
    }

    public void SetBallOnAir()
    {
        isInAir = true;
        numberJumps = 0;
    }

    public void SetBallOnGround()
    {
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        isInAir = false;
        numberJumps = 1;
    }

    public void MoveBall()
    {
        rb.AddForce(ballVelocity * moveForce * Time.fixedDeltaTime, ForceMode.VelocityChange);
    }

    public void JumpBall()
    {
        if(!isInAir)
        {
            if(numberJumps > 0)
            {
                rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, ForceMode.Impulse);
                SoundController.Instance.PlaySound("JumpSound");
            }
        }
    }

    public void BreakBall()
    {
        var horizontalVeocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        if (horizontalVeocity.magnitude >= 1)
        {
            rb.AddForce(-horizontalVeocity * (moveForce / 1.5f) * Time.fixedDeltaTime, ForceMode.Force);
        }
    }   

    public void CheckForBallBouncinessNeed()
    {
        if(rb.velocity.magnitude <= 2.5f && !isInAir)
        {
            physicMaterial.bounciness = 0;
        }
        else
        {
            physicMaterial.bounciness = 0.25f;
        }
    }

    public void GetCurrentVelocityInformation()
    {
        Debug.Log("Velocity is :" + rb.velocity);
        Debug.Log("Angular Velocity is :" + rb.angularVelocity);
    }

    public void EnablePhysics()
    {
        isPhysicsBodyActive = true;
        rb.isKinematic = false;
    }

    public void DisablePhysics()
    {
        isPhysicsBodyActive = false;
        rb.isKinematic = true;
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
                Debug.Log("Disable physics!");
                DisablePhysics();
                numberJumps = 1;
                break;
            case EventName.StartLevel:
                Debug.Log("Enable physics!");
                EnablePhysics();
                break;
        }
    }

    public void FixedUpdate()
    {
        if(isPhysicsBodyActive != false)
        {
            MoveBall();
            CheckForBallBouncinessNeed();
        }
    }
}

