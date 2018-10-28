using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SellScrollScript : MonoBehaviour {

    public TextAsset[] HotspotFiles;
    public Transform elementsParentGrid;
    public GameObject [] elementPrefab;
    public RenderTexture[] DomeRef;

    public int NoOfElements;
    
    public GameObject ElementPrefab;
    public GameObject DomePrefab;
    
    public List<GameObject> ListOfElements = new List<GameObject>();
    public List<GameObject> ListOfDomes = new List<GameObject>();
    public List<RenderTexture> ListRenderTextures = new List<RenderTexture>();

    public GameObject[] Dome360Video;
    public float x;
    public float y;

    public void Start()
    {
        buyListElements();
    }

    public void buyListElements()
    {
        Debug.Log("Starting....");
        StartCoroutine(elementList());
    }
    public IEnumerator elementList()
    {
        GameManger.Instance.GetBuyListing();
        yield return new WaitForSeconds(2f);
        NoOfElements = WebServiceHndlr.Ins.BuyingList.NoOfElements;
        Debug.Log(WebServiceHndlr.Ins.BuyingList.NoOfElements);
        InitiateBuyData();
    }
    public void InitiateBuyData()
    {
        for (int i = 0; i < WebServiceHndlr.Ins.BuyingList.NoOfElements; i++)
        {
            RenderTexture rt = new RenderTexture(256, 256, 16, RenderTextureFormat.ARGB32);
            rt.Create();
            ListRenderTextures.Add(rt);

            GameObject Dome = GameObject.Instantiate(DomePrefab) as GameObject;
            x = x + 50f;
            y = y + 50f;
            Dome.transform.position = new Vector3(x, y , 0);
            GameObject BuyingElements = GameObject.Instantiate(ElementPrefab , elementsParentGrid) as GameObject;

            Camera cam = Dome.transform.GetChild(0).GetChild(0).GetComponent<Camera>();
            Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().VideoPlayer.Pause();
            cam.targetTexture = rt;
            BuyingElements.GetComponent<SellScrollElement>().rawImage.texture = rt;

            if (i == 0)
            {
                Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().videoId = "https://www.youtube.com/watch?v=AqX6rBBLsck";
                Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().Play();
            }
            if (i == 1)
            {
                Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().videoId = "https://www.youtube.com/watch?v=Q1x_wnHR-nM";
                Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().Play();
            }
            if (i == 2)
            {
                Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().videoId = "https://youtu.be/RPW5FOBtBRo";
               Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().Play();
            //    Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>().VideoPlayer.StartFrom();
               
            }

        

            BuyingElements.GetComponent<SellScrollElement>().VideoPlayer = Dome.transform.GetChild(1).GetComponent<HighQualityPlayback>();
            BuyingElements.GetComponent<SellScrollElement>().VideoID.CameraDrag = Dome.transform.GetChild(0).GetChild(0).transform.GetComponent<CameraDragging>();
            BuyingElements.GetComponent<SellScrollElement>().VideoID.VideoIndex = i;
            BuyingElements.GetComponent<SellScrollElement>().PlayAndPause();

            BuyingElements.GetComponent<SellScrollElement>().UserName.text = WebServiceHndlr.Ins.BuyingList.BuyData[i].owner.name;
            Debug.Log(WebServiceHndlr.Ins.BuyingList.BuyData[i].owner.name);
            BuyingElements.GetComponent<SellScrollElement>().Address.text = WebServiceHndlr.Ins.BuyingList.BuyData[i].address;
            BuyingElements.GetComponent<SellScrollElement>().NoOfBed.text = WebServiceHndlr.Ins.BuyingList.BuyData[i].bed;

            BuyingElements.GetComponent<SellScrollElement>().NoOfBathroom.text = WebServiceHndlr.Ins.BuyingList.BuyData[i].bath;
            BuyingElements.GetComponent<SellScrollElement>().SequareFoot.text = WebServiceHndlr.Ins.BuyingList.BuyData[i].squareFeet;
            BuyingElements.GetComponent<SellScrollElement>().Information.text = WebServiceHndlr.Ins.BuyingList.BuyData[i].information;
        }

        Dome360Video[0].SetActive(true);
        Dome360Video[0].GetComponent<HighQualityPlayback>().videoId = "https://www.youtube.com/watch?v=jcvI-MAWc2U";
        Dome360Video[0].GetComponent<HighQualityPlayback>().Play();

    }

    public void checkForBuyDataInRes(string[] dictsToLook) {

        for (int i = 0; i < dictsToLook.Length; i++) {

            string dictToLookFor = dictsToLook[i]; //"RomitPatil";
                                                   //Debug.Log(dictToLookFor);

            //string path = "";
            //if (Application.platform == RuntimePlatform.Android)
            //{
            // path = "jar:file://" + Application.dataPath + "!/assets/ "+ dictToLookFor + " / MelloVR.json";

            //}
            //else
            //{

            //    string tempPath = Application.dataPath + "/Resources/" + dictToLookFor;
            //   Debug.Log(tempPath);
            //   if (Directory.Exists(tempPath) == false)
            //   {
            //       Debug.Log("Required directory dosen't exist, returning...");
            //       Debug.Log("Path: " + tempPath);
            //       return;
            //   }

            //   path = Application.dataPath + "/Resources/" + dictToLookFor + "/MelloVR.json";
            //}
            ////initiate the element
            //var textFile = Resources.Load<TextAsset>(dictToLookFor);
            //string text = textFile.text;
            //Debug.Log(text);
            //  GameObject ele = Instantiate(elementPrefab) as GameObject;


            //    ele.transform.parent = elementsParentGrid;
            //    ele.transform.localScale = Vector3.one;
            //   ele.transform.localPosition = new Vector3(ele.transform.localPosition.x, ele.transform.localPosition.y, 0);

            //Romit_ReadHotspotData Reader = elementPrefab[i].GetComponent<Romit_ReadHotspotData>();

            //var readerData = text;
            //JsonUtility.FromJsonOverwrite(readerData, Reader);


            //elementPrefab[i].GetComponent<SellScrollElement>().RawImageRendering.texture = DomeRef[i];
            //Dome360Video[i].GetComponent<HighQualityPlayback>().videoId = elementPrefab[i].GetComponent<Romit_ReadHotspotData>().VideoURL;
           
            //Dome360Video[i].gameObject.SetActive(true);
            //Dome360Video[i].GetComponent<MediaPlayerCtrl>().enabled = true;

        }


        //string filePath =  Application.dataPath + "/Resources";

        //if (Directory.Exists(Application.streamingAssetsPath + "/" + )) {
        //    Debug.Log(Application.persistentDataPath + "/" + GameManager.Instance.UserName);
        //    foreach (string file in Directory.GetFiles(Application.persistentDataPath + "/" + GameManager.Instance.UserName)) {

        //        Debug.Log(file);
        //        File.Delete(file);

        //    }
        //    Directory.Delete(Application.persistentDataPath + "/" + GameManager.Instance.UserName);
        //}
    }
}
