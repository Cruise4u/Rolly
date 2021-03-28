using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    public CameraRig cameraRig;

    #region Camera Setup
    public Camera playerCamera;
    public GameObject viewTarget;
    private Vector3 cameraOffset;
    private float cameraPitch;
    private float zoom;
    #endregion

    public void OnEnable()
    {
        cameraRig = new CameraRig();
        cameraRig.Init(playerCamera, viewTarget, zoom);
        cameraRig.SetCameraValues(new Vector3(5, -6.0f, 0.0f),4.0f,3.0f);
    }

    public void LateUpdate()
    {
        cameraRig.SmoothCameraPosition();
    }
}

public class CameraRig
{
    Camera selectedCamera;
    GameObject viewTarget;
    float zoom;
    Vector3 cameraOffset;
    float cameraPitch;

    public void Init(Camera selectedCamera,GameObject viewTarget,float zoom)
    {
        this.selectedCamera = selectedCamera;
        this.viewTarget = viewTarget;
        this.zoom = zoom;
    }

    public void SetCameraValues(Vector3 cameraOffset,float zoom,float cameraPitch)
    {
        this.cameraOffset = cameraOffset;
        this.zoom = zoom;
        this.cameraPitch = cameraPitch;
    }

    public void SmoothCameraPosition()
    {
        selectedCamera.transform.position = viewTarget.transform.position - (this.cameraOffset * zoom);
        selectedCamera.transform.LookAt(viewTarget.transform.position + Vector3.up * this.cameraPitch);
    }
}


