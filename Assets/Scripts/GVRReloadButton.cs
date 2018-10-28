using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GVRReloadButton : MonoBehaviour, TimeInputHandler
{
    public HighQualityPlayback domeHighQualityPlayback;
    public void Start()
    {
        domeHighQualityPlayback = FindObjectOfType<HighQualityPlayback>();

    }

    public void HandleTimedInput()
    {
        ReloadBTN();
    }
    public void ReloadBTN()
    {
        domeHighQualityPlayback.gameObject.GetComponent<HighQualityPlayback>().RetryPlayYoutubeVideo();
    }
}
