using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GVRCloseButton : MonoBehaviour , TimeInputHandler
{
    public void HandleTimedInput()
    {
        CloseBTN();
    }

    public void CloseBTN()
    {

        StartCoroutine(UnloadDevice("Cardboard"));

    }
    IEnumerator UnloadDevice(string newDevice)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;

        UnityEngine.XR.XRSettings.enabled = false;
        SceneManager.LoadScene("BuySellScene");
        Screen.orientation = ScreenOrientation.Portrait;
    }
}
