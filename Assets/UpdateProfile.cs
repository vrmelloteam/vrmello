using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateProfile : MonoBehaviour
{
    public Transform parent;
    public InputField NameInput;
    public InputField EmailAddress;
    public Dropdown Profession;
    public InputField TravalDistance;
    public InputField ZipCode;
    public InputField City;

    public Text Label;
    public string LabelName;

    public GameObject ProfileAgentEdit;
    public GameObject ProfileDesignerEdit;
    public GameObject ProfilePhotographerEdit;

    public GameObject ProfileAgent;
    public GameObject ProfileDesigner;
    public GameObject ProfilePhotographer;

    public Text Email;
    public Text Name;
    public Text Role ;
    public Text _city;
    public Text Zipcode;
    public Text travalDistance;

	// Use this for initialization
	void Start ()
    {
        
        Profession.onValueChanged.AddListener(delegate {
            DropdownValueChanged(Profession);
        });

    }

    void OnEnable()
    {
        if(LabelName == "Agent")
            Profession.value = 0;
        if(LabelName == "VR Photographer")
            Profession.value = 1;
        if(LabelName == "Designer")
            Profession.value = 2;
        StartCoroutine(CrutchROutine());
    }

    IEnumerator CrutchROutine()
    {
        yield return null;
//        Label.text = LabelName;
    }

    void OnDisable()
    {
//        Label.text = LabelName;
    }

    // Update is called once per frame
    public void UpdateingProfile ()
    {
        string client_id; string client_secret; string profession; string travelDistance; string city; string zipCode;

        client_id = "5abceb4dbbe3025ac525abc4";
        client_secret = "abcd1234";
        profession = Profession.captionText.text;
        if (TravalDistance != null)
            travelDistance = TravalDistance.text;
        else
            travelDistance = "";
        
        if (City != null)
            city = City.text;
        else
            city = "";

        zipCode = ZipCode.text;

        WebServiceHndlr.Ins.StartCoroutine(WebServiceHndlr.Ins.UpdateProfile(profession, travelDistance, city, zipCode ,jsonData => {
            // var Status = jsonData["status"].ToString();
            //  var SucessMsg = jsonData["message"].ToString();

            //Show msg that profile is updated successfully

            if (profession == "Agent") {
                Name.text = NameInput.text;
                Role.text = Profession.captionText.text;
                Email.text = EmailAddress.text;
                Zipcode.text = ZipCode.text;
                ProfileAgent.SetActive(true);
                ProfileAgentEdit.SetActive(false);
            }

            if (profession == "VR Photographer")
            {
                Name.text = NameInput.text;
                Role.text = Profession.captionText.text;
                Email.text = EmailAddress.text;
                Zipcode.text = ZipCode.text;
                _city.text = City.text;
                travalDistance.text = TravalDistance.text;


                ProfilePhotographer.SetActive(true);
                ProfilePhotographerEdit.SetActive(false);
            }

            if (profession == "Designer")
            {
                Name.text = NameInput.text;
                Role.text = Profession.captionText.text;
                Email.text = EmailAddress.text;
                Zipcode.text = ZipCode.text;
                _city.text = City.text;

                ProfileDesigner.SetActive(true);
                ProfileDesignerEdit.SetActive(false);
            }
        }));

    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {
       string n =  change.captionText.text;

        if (change.captionText.text == "Agent")
        {

            parent.gameObject.SetActive(false);
            ProfileAgentEdit.SetActive(true);
            DestroyObject (gameObject.GetComponentInChildren<Canvas> ().gameObject);

        }

        if (change.captionText.text == "VR Photographer")
        {

            parent.gameObject.SetActive(false);
            ProfilePhotographerEdit.SetActive(true);
            DestroyObject (gameObject.GetComponentInChildren<Canvas> ().gameObject);

            
        }

        if (change.captionText.text == "Designer")
        {

            parent.gameObject.SetActive(false);
            ProfileDesignerEdit.SetActive(true);
            DestroyObject (gameObject.GetComponentInChildren<Canvas> ().gameObject);


        }

    }
}
