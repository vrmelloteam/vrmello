using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Romit_MenuHotspot : MonoBehaviour, TimeInputHandler {

    public GameObject MenuContainer;
    public GameObject MenuItemPrefab;
    public GameObject HotspotDataObj;
    public Romit_ReadHotspotData Data_MenuHotspot;
    //public Romit_UploadData Data_Upload;
    public GameObject HotspotDataDisplayContainer;

    public List<string> HotspotNames = new List<string>();
    public List<string> StartTimes = new List<string>();
    public List<string> EndTimes = new List<string>();
    public List<Texture> IconTexture = new List<Texture>();
    public bool MenuHide;
    bool clicked;

    
    // Use this for initialization
    public void IntiateMenuHotapot()
    {
        Debug.Log("Menu Item Inititae");
        for (int i = 0; i < HotspotNames.Count; i++)
        {
            
            GameObject MenuItem = GameObject.Instantiate(MenuItemPrefab);

            MenuItem.transform.parent = MenuContainer.transform;
            MenuItem.transform.localScale = new Vector3(1, 1, 1);
            MenuItem.transform.localRotation = new Quaternion(0,0,0,0);
            MenuItem.transform.localScale = new Vector3(MenuItem.transform.localScale.x, MenuItem.transform.localScale.y, 0);
            MenuItem.GetComponent<Romit_MenuFunction>().HotspotName = HotspotNames[i];
            MenuItem.GetComponent<Romit_MenuFunction>().StartTime = StartTimes[i];
            MenuItem.GetComponent<Romit_MenuFunction>().EndTime = EndTimes[i];
          //  MenuItem.GetComponent<Romit_MenuFunction>().IconTexture = IconTexture[i];
            //nuItem.GetComponent<Romit_MenuFunction>().ClaculateTime();

        }

    }
	//// Update is called once per frame
	//void Update () {
		
	//}
    public void ClickOnVisible()
    {
        

        if (clicked == false)
            StartCoroutine(WaitForSce());

    }
    public void HandleTimedInput()
    {
        ClickOnVisible();
    }

    IEnumerator WaitForSce()
    {
        MenuHide = !MenuHide;
        MenuContainer.gameObject.transform.parent.transform.parent.gameObject.SetActive(MenuHide);
        clicked = true;
        yield return new WaitForSeconds(0);
        clicked = false;
    }
    public void ExitFromDome() {

       // GameManager.Instance.FifthPanal.SetActive(true);
    }
    public void Close() {

        //GameManager.Instance.FifthDome.SetActive(true);
        //GameManager.Instance.FifthPanal.SetActive(true);
        //GameManager.Instance.PreviewSetup.SetActive(false);
        //GameManager.Instance.FifthDomeref.videoId = GameManager.Instance.VideoURL;
        HotspotDataDisplay();
    }

    public void HotspotDataDisplay()
    {

        for (int i = 0; i < Data_MenuHotspot.HotspotData.Length; i++)
        {

            GameObject HPdata = GameObject.Instantiate(HotspotDataObj);
            HPdata.transform.parent = HotspotDataDisplayContainer.transform;
            HPdata.transform.localScale = new Vector3(1, 1, 1);
            HPdata.transform.localPosition = new Vector3(0, 0, 0);
            HPdata.transform.GetChild(0).GetComponent<InputField>().text = Data_MenuHotspot.HotspotData[i].HotspotName;
            HPdata.transform.GetChild(1).GetComponent<InputField>().text = Data_MenuHotspot.HotspotData[i].StartTime;
            HPdata.transform.GetChild(2).GetComponent<InputField>().text = Data_MenuHotspot.HotspotData[i].EndTime;

        }
    }

    public void ReloadVideo() {
        //GameManager.Instance.FifthDomeref.GetComponent<HighQualityPlayback>().RetryPlayYoutubeVideo();
    }

}
