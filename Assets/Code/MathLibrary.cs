using UnityEngine;

public static class MathLibrary
{
    public static Vector3 GetRotatedVectorOnYAxis(Vector3 vector, float angle)
    {
        float xAngle = vector.x * Mathf.Cos(angle) - vector.z * Mathf.Sin(angle);
        float zAngle = vector.x * Mathf.Sin(angle) + vector.z * Mathf.Cos(angle);
        return new Vector3(xAngle, 1.0f, zAngle);
    }

    public static Vector3 GetRotatedVectorOnZAxis(Vector3 vector, float angle)
    {
        float xAngle = vector.x * Mathf.Cos(angle) + vector.y * Mathf.Sin(angle);
        float yAngle = vector.x * -Mathf.Sin(angle) + vector.y * Mathf.Cos(angle);
        return new Vector3(xAngle, yAngle, 1.0f);
    }

}