using UnityEngine;
using UnityEngine.UI;

public class InGameCamera : CommonUIButton
{
    public InGameCameraController cameraController;

    void Awake()
    {
        base.Start();
    }



    public void OnClickZoomButton()
    {
        if (cameraController != null)
        {
            cameraController.isZoomedIn = !cameraController.isZoomedIn;
        }
    }
}
