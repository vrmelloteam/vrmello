using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public struct hotspotContainer {

    public string HotspotName;
    public string StartTime;
    public string EndTime;
    public Texture IconImage;
}

public class Romit_ReadHotspotData : MonoBehaviour {

   

    public hotspotContainer[] HotspotData;
    public string VideoURL;
    public Texture ProfilePic;
    public Texture PropertyPic;
    public string ProfilePIcName;
    public string PropertyPIcName;
    public string UserName;
    public string CountryName;
    public string City;
    public string ZipCode;
    public string Address;
    public string Contact;
    public string Email;
    public string PropertyInfo;
    public string Contact_Information;
    public string BathRoomNo;
    public string BedRoomNo;
    public string KitchenRoomNO;
    public string squareFeet;
    public string Price;
    public bool BuyToggle;
    public bool SellToggle;
    public bool RentTOggle;
    public string TokenID;

    public Romit_MenuHotspot MenuHotapot;

    public  static  int indexer;
    // Use this for initialization
    void Start () {
		
	}
    private void OnEnable()
    {
      //ReadData();
    }
    public void ReadData()
    {
        string path ="";
        Debug.Log("You are reading ");
        if (indexer == 0)
        {
#if UNITY_ANDROID
            path = "jar:file://" + Application.dataPath + "!/assets/Mark Twain";
           
#endif
        path = Application.dataPath + "/Resources/Mark Twain.json";
        Debug.Log(path);


#if UNITY_IOS
           path = Application.dataPath + "/Raw/Mark Twain";
#endif
        }
        if (indexer == 1)
        {
#if UNITY_ANDROID
            path = "jar:file://" + Application.dataPath + "!/assets/Romit";
#endif

            path = Application.dataPath + "/Resources/Romit.json";
                Debug.Log(path);

#if UNITY_IOS
           path = Application.dataPath + "/Raw/Romit";
#endif
        }
        if (indexer == 2)
        {
#if UNITY_ANDROID
            path = "jar:file://" + Application.dataPath + "!/assets/RomitPatil";
#endif
            path = Application.dataPath + "/Resources/RomitPatil.json";
                Debug.Log(path);
#if UNITY_IOS
           path = Application.dataPath + "/Raw/RomitPatil";
#endif

        }

        Romit_ReadHotspotData Reader = GetComponent<Romit_ReadHotspotData>();
        indexer++;
        string readerData = File.ReadAllText(path);
        Debug.Log(readerData);
        JsonUtility.FromJsonOverwrite(readerData, Reader);
        for (int i = 0; i < HotspotData.Length; i++)
        {
            Debug.Log("YOu are setuping the data");

            MenuHotapot.HotspotNames.Add(HotspotData[i].HotspotName);
            MenuHotapot.StartTimes.Add(HotspotData[i].StartTime);
            MenuHotapot.EndTimes.Add(HotspotData[i].EndTime);
            MenuHotapot.IconTexture.Add(HotspotData[i].IconImage);
        }
        MenuHotapot.IntiateMenuHotapot();

        if (indexer == 0)
        {
            Debug.Log(VideoURL);

          transform.GetComponent<SellScrollElement>().VideoPlayer.videoId = VideoURL;
            transform.GetComponent<SellScrollElement>().VideoPlayer.RetryPlayYoutubeVideo();

            Debug.Log(path);
        }
        if (indexer == 1)
        {
         transform.GetComponent<SellScrollElement>().VideoPlayer.videoId = VideoURL;
            transform.GetComponent<SellScrollElement>().VideoPlayer.RetryPlayYoutubeVideo();
        }
        if (indexer == 2)
        {
          transform.GetComponent<SellScrollElement>().VideoPlayer.videoId = VideoURL;
            transform.GetComponent<SellScrollElement>().VideoPlayer.RetryPlayYoutubeVideo();
        }
    }

}
