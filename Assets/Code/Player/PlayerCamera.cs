using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public CameraRig cameraRig;

    #region Camera Setup

    public Camera playerCamera;
    public GameObject viewTarget;
    public Vector3 cameraOffset;
    public float cameraPitch;

    public float zoomSpeed;
    public float currentZoom;
    public float maxZoom;
    public float minZoom;
    #endregion

    public void SetCameraValues()
    {
        cameraOffset = new Vector3(5, -6.0f, 0.0f);
        cameraPitch = 3.0f;
    }

    public void Start()
    {
        cameraRig = new CameraRig();
        cameraRig.InitializeCameraConfiguration(playerCamera, viewTarget);
        SetCameraValues();
    }

    public void LateUpdate()
    {
        cameraRig.Zoom(zoomSpeed, minZoom, maxZoom);
        cameraRig.SmoothCameraPosition(cameraOffset,cameraPitch);
    }
}

public class CameraRig
{
    Camera selectedCamera;
    GameObject viewTarget;
    float currentZoom;

    public void InitializeCameraConfiguration(Camera selectedCamera,GameObject viewTarget)
    {
        this.selectedCamera = selectedCamera;
        this.viewTarget = viewTarget;
    }

    public void Zoom(float zoomSpeed,float minZoom,float maxZoom)
    {
        currentZoom = 4.5f;
    }

    public void SmoothCameraPosition(Vector3 cameraOffset, float cameraPitch)
    {
        selectedCamera.transform.position = viewTarget.transform.position - (cameraOffset * currentZoom);
        selectedCamera.transform.LookAt(viewTarget.transform.position + Vector3.up * cameraPitch);
    }

}


