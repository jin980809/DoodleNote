using UnityEngine;
using UnityEngine.UI;

public class InGameCamera : CommonUIButton
{
    public InGameCameraController cameraController;

    void Start()
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
