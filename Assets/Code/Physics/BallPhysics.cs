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

    public void ActivatePhysics()
    {
        rb.isKinematic = false;
    }

    public void DeactivatePhysics()
    {
        rb.isKinematic = true;
    }

    public void Move(Vector3 direction, float axisValue)
    {
        rb.AddForce(direction * axisValue * moveForce * Time.fixedDeltaTime, forceMode);
    }

    public void Jump()
    {
        if(!isInAir)
        {
            rb.AddForce(Vector3.up * jumpForce * Time.fixedDeltaTime, jumpMode);
        }
    }

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

