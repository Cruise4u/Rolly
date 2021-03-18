using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class TrajectoryPrediction : MonoBehaviour
{
    public BallPhysics ballPhysics;
    public GameObject cannon;
    public GameObject ballEndPoint;
    public Vector3 trajectoryDirection;
    public LineRenderer lineRenderer;


    public int timeSteps;
    public float gravity;
    public float velocity;
    public float height;
    public float trajectoryAngle;


    public void SetVariablesValues()
    {
        gameObject.GetComponent<LineRenderer>().positionCount = timeSteps;
        gravity = -Physics.gravity.y;
        height = ballPhysics.transform.position.y;
    }

    public Vector3 GetVelocity(Vector3 a,Vector3 b)
    {
        return a - b;
    }

    public Vector3 CalculatePrediction(Vector3 direction,float time)
    {
        float initialVelocityX = direction.x * 1.0f;
        float x = initialVelocityX * time + ballPhysics.transform.position.x;

        float initialVelocityY = direction.y * 1.0f;
        float y = height + initialVelocityY * time - (0.5f * gravity) * time * time;
        return new Vector3(x, y, 0.0f);
    }
    public void DisplayPrediction()
    {
        for (int i = 0; i < timeSteps; i++)
        {
            float simulationTime = i / 20.0f;
            Vector3 trajectoryPosition = CalculatePrediction(trajectoryDirection, simulationTime);
            lineRenderer.SetPosition(i, trajectoryPosition);
        }
    }


    public void Start()
    {
        SetVariablesValues();
        trajectoryDirection = ballPhysics.transform.position - cannon.transform.position;
        DisplayPrediction();
    }

}