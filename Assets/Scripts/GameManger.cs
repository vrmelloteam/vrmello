using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using Kakera;
using System.IO;

public class GameManger : MonoBehaviour {

    private static GameManger _instance;
    public static GameManger Instance

    {
        get
        {
            if (_instance == null) {

                GameObject go = new GameObject("GameManger");
                go.AddComponent<GameManger>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    private void Start() {
        ViewCanvas360.SetActive(false);
        VRHomeCanvas.SetActive(true);
        string Value = (Common.token_type + " " + Common.access_token);
        StartCoroutine(WebServiceHndlr.Ins.GetProfile(Value));
    }

    public void btnSetProfilePicClicked() {
       // FindObjectOfType<PickerController>().OnPressShowPicker();
    }

    public InputField PeofileEmail;
    public Dropdown profession;
    public InputField travelDistance;
    public Dropdown city;
    public InputField zipcode;
    public void BtnSubmitProfileClicked()
    {

        StartCoroutine(WebServiceHndlr.Ins.UpdateProfile(profession.captionText.text, travelDistance.text , city.captionText.text, zipcode.text, jsonData => {
       //     var Status = jsonData["status"].ToString();
          //  var SucessMsg = jsonData["message"].ToString();

            //Show msg that profile is updated successfully
        }));
    }

    public static int ActiveVideoIndex;
    public static bool ActiveTouch;
    public SellScrollScript sellScrollPanel;
    public GameObject BackgroundVideoPlayer;

    public void ShowBuyScrollPopup()
    {
        //For now check for the "RomitPatil" Folder, Later we will look for the token named directory
        sellScrollPanel.gameObject.SetActive(true);
        BackgroundVideoPlayer.gameObject.SetActive(false);
    //    sellScrollPanel.checkForBuyDataInRes(new string[] { "Mark Twain", "RomitPatil" });
    }

    public GameObject ViewCanvas360;
    public GameObject VRHomeCanvas;
    public GameObject BackgroudDome;
    // Only for test
    public GameObject TempDom;
    public bool VROptionTrigger;
    public SellScrollScript BuyScrollPanel;
    public void btnBuyClicked(GameObject PanalOn)
    {
        ViewCanvas360.SetActive(true);
        VRHomeCanvas.SetActive(false);
        BackgroudDome.SetActive(false);
        buy.SetActive(true);
        PanalOn.SetActive(false);
        TempDom.gameObject.SetActive(true);
        ShowBuyScrollPopup();
       // BuyScrollPanel.checkForBuyDataInRes(new string[] { "Mark Twain", "RomitPatil" , "Romit"});
    }
    public GameObject buy;
    public void btnBackClicked()
    {
        ViewCanvas360.SetActive(false);
        VRHomeCanvas.SetActive(true);
        BackgroudDome.SetActive(true);
        BackgroundVideoPlayer.SetActive(true);
        TempDom.gameObject.SetActive(false);
    }

    public GameObject SellPanal;
    public void btnSellClicked(GameObject PanalOn)
    {
        SellPanal.SetActive(true);
        PanalOn.SetActive(false);
    }

    public GameObject UploadCad;
    public void btnPreDevelopedProperty(GameObject PanalOn)
    {
        UploadCad.gameObject.SetActive(true);
        PanalOn.SetActive(false);
    }

    public void btnBack (GameObject backTo)
    {
       
        backTo.SetActive(true);
     }
    public void DisablePnal(GameObject PanalOn)
    {
        PanalOn.SetActive(false);

    }

    public GameObject SelectADay;
    public void ExistingProperty(GameObject PanalOn)
    {
        SelectADay.SetActive(true);
        PanalOn.SetActive(false);
    }

    public GameObject sellDetailPanal;
    public void SellDetails(GameObject OnPanal)
    {
        sellDetailPanal.SetActive(true);
        OnPanal.SetActive(false);
    }

    public void CompleteSellDetails(GameObject OnPanal)
    {
        VRHomeCanvas.SetActive(true);
        OnPanal.SetActive(false);
    }

    public GameObject VrMelloAgent;
    public void MyProjectsVrmelloDesigner(GameObject OnPanal)
    {
        VrMelloAgent.SetActive(true);
        OnPanal.SetActive(false);
    }

    public GameObject contactBuyer;
    public void ContactBuyers(GameObject OnPanal)
    {
        OnPanal.SetActive(false);
    }

    public GameObject contactVRPhotographer;
    public void ContactVRPhotographer(GameObject OnPanal)
    {
        contactVRPhotographer.SetActive(true);
        OnPanal.SetActive(false);
    }

    public GameObject contactSeller;
    public void ContactSeller(GameObject OnPanal)
    {
        contactSeller.SetActive(true);
        OnPanal.SetActive(false);
    }

    public GameObject contactDesigner;
    public void ContactDesigner(GameObject OnPanal)
    {
        contactDesigner.SetActive(true);
        OnPanal.SetActive(false);
    }


    public GameObject ProfilePanal;
    public GameObject VrMelloOption;

    public void ProfilePanalClicked(GameObject OnPanal)
    {
       
         ProfilePanal.SetActive(true);
        OnPanal.SetActive(false);
        //    VrMelloOption.GetComponent<Animator>().SetTrigger("Hide");
        //    VrMelloOption.transform.GetChild(0).transform.gameObject.SetActive(false);
        VrMelloPanalOpen();
    }
    public void HideVrMelloOption()
    {
      //  VrMelloOption.GetComponent<Animator>().SetTrigger("Hide");
     //  VrMelloOption.transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(true);
        VrMelloOption.transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(false);
    }

    public void VrMelloPanalOpen()
    {
        VROptionTrigger = !VROptionTrigger;
        VrMelloOption.SetActive(true);
        VrMelloOption.transform.GetChild(0).transform.gameObject.SetActive(true);

        if (VROptionTrigger)
        {
          //  VrMelloOption.transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(false);
            VrMelloOption.transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(true);
            VrMelloOption.GetComponent<Animator>().SetTrigger("Trigger");
        }
        else if (!VROptionTrigger)
        {


            VrMelloOption.GetComponent<Animator>().SetTrigger("Hide");
            VrMelloOption.transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(true);
         //   VrMelloOption.transform.GetChild(0).GetChild(1).transform.gameObject.SetActive(false);
        }

    }

    public GameObject AgentProfile;
    public Text AgentProfileText;
    public void AgentProfileUpdate(GameObject UpdateingProfile)
    {
        UpdateingProfile.SetActive(true);
        AgentProfile.SetActive(false);
        
    }

    public Text DesignerProfileText;
    public GameObject DesignerProfile;
    public void DesignerProfileUpdate(GameObject UpdateingDesignerProfile)
    {
        UpdateingDesignerProfile.SetActive(true);
        DesignerProfile.SetActive(false);

    }

    public Text VrPhotograoherText;
    public GameObject VrPhotographerProfile;
    public void VrPhotographerProfileProfileUpdate(GameObject UpdateinVrPhotographerProfile)
    {
        UpdateinVrPhotographerProfile.SetActive(true);
        VrPhotographerProfile.SetActive(false);

    }

    public GameObject ProfilePanalEdit;
    public string ProfileEmailID;
    public string ProfileName;
    public string Role;
    public string ProfilecCity;
    public string Zipcode;
    public string Distance;

    public void ProfileEditPanalClicked(GameObject OnPanal)
    {
        AgentProfile.SetActive(false);
        DesignerProfile.SetActive(false);
        VrPhotographerProfile.SetActive(false);
        OnPanal.SetActive(true);
    }

    public GameObject Details;
    public void GetBuyListing()
    {
        StartCoroutine(WebServiceHndlr.Ins.Getlistings());
    }
}
