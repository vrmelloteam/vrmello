using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;
public class CardboardSceneMgr : MonoBehaviour {

    public string TokenID;
    public HighQualityPlayback domeHighQualityPlayback;

    // Use this for initialization
    private void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Start () {
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        StartCoroutine(loadDevice("Cardboard"));
        Screen.orientation = ScreenOrientation.LandscapeLeft;
        InitMenuHotspot();

        domeHighQualityPlayback.VideoPlayer.m_strFileName = Common.buySellScreenToVR_Data.VideoURL;
        TokenID = Common.buySellScreenToVR_Data.TokenID;

        domeHighQualityPlayback.gameObject.SetActive(true);
    }

    IEnumerator loadDevice(string newDevice)
    {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
     
        UnityEngine.XR.XRSettings.enabled = true;
    }

    IEnumerator SwitchToVR() {

        string desriedDevice = "cardboard";

        //Some vr Devices do not support reloading when already active see

        if (string.Compare(UnityEngine.XR.XRSettings.loadedDeviceName, desriedDevice, true) != 0)
        {
            UnityEngine.XR.XRSettings.LoadDeviceByName(desriedDevice);

            yield return null;
        }

        // Now it's ok to enable VR mode.
        UnityEngine.XR.XRSettings.enabled = true;
    }

    public Romit_MenuHotspot menuHotspot;

    void InitMenuHotspot()
    {
        menuHotspot.HotspotNames = Common.buySellScreenToVR_Data.HotspotData.Select(d => d.HotspotName).ToList();
        menuHotspot.StartTimes = Common.buySellScreenToVR_Data.HotspotData.Select(d => d.StartTime).ToList();
        menuHotspot.EndTimes = Common.buySellScreenToVR_Data.HotspotData.Select(d => d.EndTime).ToList();
        menuHotspot.IntiateMenuHotapot();
    }

    private void Update()
    {
        // int percent =  domeHighQualityPlayback.VideoPlayer.GetCurrentSeekPercent();
     //   int percent = domeHighQualityPlayback.VideoPlayer.GetDuration();
      //  Debug.Log(percent);
    }
}
