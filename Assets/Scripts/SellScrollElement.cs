using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SellScrollElement : MonoBehaviour {

    public RenderTexture rt;
    public Camera camera;
    public RawImage rawImage;
    public bool toggle;
    public Text UserName;
    public Text Address;
    public Text NoOfBed;
    public Text NoOfBathroom;
    public Text SequareFoot;
    public Text Information;
    public GameObject Details;
    public RawImage RawImageRendering;
    public HighQualityPlayback VideoPlayer;
    public GameObject Cardboard;
    public GameObject reload;
    public Text Title;
    public VideoID VideoID;

    private GameObject BackButton;
    void Start()
    {
      
      
    } 
    public void btnCardboardClicked() {

        var dataRef = GetComponent<Romit_ReadHotspotData>();

        Common.buySellScreenToVR_Data = new BuySellScreenToVR_Data() {
            HotspotData = dataRef.HotspotData,
            VideoURL = VideoPlayer.VideoPlayer.m_strFileName,
            TokenID = dataRef.TokenID
        };

        SceneManager.LoadScene("InsideVR");
    }

    public void Reload() {

       
        VideoPlayer.RetryPlayYoutubeVideo();
       
    }

    public void Detatis() {

        GameManger.Instance.Details.SetActive(true);
        GameManger.Instance.Details.GetComponent<Details>().Name.text = UserName.text;
        GameManger.Instance.Details.GetComponent<Details>().Address.text = Address.text;
        GameManger.Instance.Details.GetComponent<Details>().BedNo.text = NoOfBed.text;
        GameManger.Instance.Details.GetComponent<Details>().BathroomNO.text = NoOfBathroom.text;
        GameManger.Instance.Details.GetComponent<Details>().Information.text = Information.text;
        GameManger.Instance.Details.GetComponent<Details>().VideoPlayer.texture =RawImageRendering.texture;

        for (int i = 0; i < transform.parent.childCount; i++)
        {
            if (transform.GetChild(i).GetComponent<SellScrollElement>() != null)
            {

            transform.GetChild(i).GetComponent<SellScrollElement>().VideoPlayer.VideoPlayer.Pause();
            }
        }

        VideoPlayer.VideoPlayer.Play();
        GameManger.Instance.buy.SetActive(false);

    }

    
    public void DeactiveDetails()
    {
        Details.gameObject.SetActive(false);
        GameObject.FindGameObjectWithTag("Title").GetComponent<Text>().text = "Buy";
        BackButton.SetActive(true);
    }

    public void PlayAndPause()
    {
        if (toggle)
        {
            VideoPlayer.VideoPlayer.Pause();
            toggle = !toggle;
        }
        else
        {
            VideoPlayer.VideoPlayer.Play();
            toggle = !toggle;
        }
    }

    public void Update()
    {
        var dataRef = GetComponent<Romit_ReadHotspotData>();
        //  UserName.text = dataRef.UserName;
        //  Address.text = dataRef.Address;
        //   Debug.Log(VideoPlayer.VideoPlayer.GetCurrentState());
        //string state = VideoPlayer.VideoPlayer.GetCurrentState().ToString();
        //if (state == "PLAYING" )
        //{
        //    reload.SetActive(false);
        //    if (VideoPlayer.VideoPlayer.GetCurrentSeekPercent() == 3) {

        //    Cardboard.SetActive(true);
        //    }
        //}
        //else {
        //    Cardboard.SetActive(false);
        //    reload.SetActive(true);
        //}


        if (VideoPlayer != null)
        {
            string State = VideoPlayer.VideoPlayer.GetCurrentState().ToString();
               // Debug.Log(State);
            if (State == "PLAYING")
            {
                reload.SetActive(false);
                if (VideoPlayer.VideoPlayer.GetCurrentSeekPercent() == Random.Range(0,10))
                {

                    Cardboard.SetActive(true);
                  


                }
            }
            else
            {
                Cardboard.SetActive(false);
                   reload.SetActive(true);
            }
        }
    }

    
}
