using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Romit_MenuFunction : MonoBehaviour, TimeInputHandler
{

    public string HotspotName;
    public string StartTime;
    public string EndTime;
    public Texture IconTexture;
    public float startTime;
    public float endTime;
    public Text HotsotName;
    public RawImage IconImage;
    public HighQualityPlayback domeHighQualityPlayback;
    // Use this for initialization
    void Start () {
        domeHighQualityPlayback = FindObjectOfType<HighQualityPlayback>();

        startTime = float.Parse(StartTime);
        endTime = int.Parse(EndTime);
    }
   

    //public void ClaculateTime() {
    //    string Min = StartTime;
    //    string Min2 = Ending;
    //    int RemoveIndex = Min.IndexOf(':');
    //    int RemoveIndex2 = Min2.IndexOf(':');
    //    Debug.Log(RemoveIndex);
    //    Debug.Log(RemoveIndex2);
    //    //  Min = Min.Substring(RemoveIndex , Min.Length -1);
    //    string Remove = Min.Substring(RemoveIndex);
    //    string Remove2 = Min2.Substring(RemoveIndex2);
    //    Debug.Log(Remove2);
    //    Min = Min.Replace(Remove, "");
    //    Min2 = Min2.Replace(Remove2, "");
    //    Debug.Log(Min);
    //    Debug.Log(Min2);

    //    float minInt = float.Parse(Min);
    //    float minInt2 = float.Parse(Min2);
    //    if (minInt > 0) {
    //        minInt = minInt * 60f;
    //        minInt2 = minInt2 * 60f;
    //    }
    //    Debug.Log(minInt);
    //    Debug.Log(minInt2);

    //    string Sce = StartTime;
    //    string Sce2 = Ending;
    //    int RemoveIndexSce = Sce.IndexOf(':');
    //    int RemoveIndexSce2 = Sce2.IndexOf(':');
    //    Debug.Log(RemoveIndexSce);
    //    Debug.Log(RemoveIndexSce2);
    //    string RemoveMin = Sce.Substring(RemoveIndex);
    //    string RemoveMin2 = Sce2.Substring(RemoveIndex2);
    //    Debug.Log(RemoveMin);
    //    Debug.Log(RemoveMin2);

    //    Sce = RemoveMin.Replace(":", "");
    //    Sce2 = RemoveMin2.Replace(":", "");
    //    Debug.Log(Sce);
    //    Debug.Log(Sce2);
    //    float SceFlot = float.Parse(Sce);
    //    float SceFlot2 = float.Parse(Sce2);
    //    startTime = minInt + SceFlot;
    //    EndTime = minInt2 + SceFlot2;
    //    Debug.Log(startTime);
    //    Debug.Log(EndTime);
    //    // startTime = float.Parse(s);
      
    //    //EndTime = float.Parse(s);

    //    HotsotName.text = HotspotName;
    //    IconImage.texture = IconTexture;
    //    HotsotName.text = HotspotName;
    //}   // Update is called once per frame

    public void HandleTimedInput()
    {
        // GameManager.Instance.PrviewDome.GetComponent<VideoController>().progressSlider.value = startTime;
        // GameManager.Instance.PrviewDome.GetComponent<VideoController>().Seek();
        //  int time = (int)startTime + 1000;
        Debug.Log(startTime);
        domeHighQualityPlayback.VideoPlayer.SetSeekBarValue(startTime);
       
        //domeHighQualityPlayback.VideoPlayer.Play();
        Debug.Log(HotspotName + "::: I am the video Start time" + startTime);
        //domeHighQualityPlayback.unityVideoPlayer.time = startTime;
        // domeHighQualityPlayback.audioVplayer.time = startTime;
        //   domeHighQualityPlayback.gameObject.GetComponent<VideoController>().sourceVideo.time = startTime;
        // domeHighQualityPlayback.gameObject.GetComponent<VideoController>().sourceAudioVideo.time = startTime;
    }
    public void ClickMenuHotspot()
    {
        Debug.Log("Set the time");
        // GameManager.Instance.PrviewDome.GetComponent<VideoController>().progressSlider.value = startTime;
        //  GameManager.Instance.PrviewDome.GetComponent<VideoController>().Seek();

        // GameManager.Instance.PrviewDome.GetComponent<VideoController>(). sourceVideo.time = Mathf.RoundToInt(startTime);
        // GameManager.Instance.PrviewDome.GetComponent<VideoController>().sourceAudioVideo.time = Mathf.RoundToInt(startTime);
        //GameManager.Instance.PrviewDome.GetComponent<VideoController>().PlayButton();
     //   domeHighQualityPlayback.VideoPlayer.SeekTo(550000);
    }
    public void Update()
    {
   
      //  domeHighQualityPlayback.VideoPlayer.SeekTo(55);
        HotsotName.text = HotspotName;
        gameObject.GetComponent<RectTransform>().localPosition = new Vector3(gameObject.GetComponent<RectTransform>().localPosition.x , gameObject.GetComponent<RectTransform>().localPosition.y , 0);
    }
}
