using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class FocusMode : MonoBehaviour {

    private bool mVuforiaStarted = false;

    // Use this for initialization
    void Start()
    {
        VuforiaARController.Instance.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        VuforiaARController.Instance.RegisterOnPauseCallback(OnPaused);
    }


    private void OnVuforiaStarted()
    {
    CameraDevice.Instance.SetFocusMode(
   CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
    private void OnPaused(bool paused)
    {
        if (!paused) // resumed
        {
            // Set again autofocus mode when app is resumed
            CameraDevice.Instance.SetFocusMode(
                CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }
}
