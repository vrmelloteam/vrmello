using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;

public class WebServiceHndlr : MonoBehaviour {

    const string URL_SERVER = "http://138.68.1.23/user/";
    const string URL_LOGIN =  "http://138.68.1.23/oauth/token";
    const string URL_REGISTER = URL_SERVER + "signup";
    const string URL_RESEND = URL_SERVER + "resendOTP";
    const string URL_VERIFYOPT = URL_SERVER + "verifyOTP";
    const string URL_FORGETPASSWORD = URL_SERVER + "forgotPassword";
    const string URL_LISTING = URL_SERVER + "listing";

    public buyingListData BuyingList;

    public string acess_token;
    public string token_type;

    public static WebServiceHndlr Ins = null;
    private void Awake() {
        Ins = this;

       
    }

    public void Start()
    {
       
    }


    public IEnumerator RegisterUser(string email, string mobile, string password, 
                                System.Action<JsonData> callback) {

        WWWForm form = new WWWForm();
      
        //form.AddField("client_id", "5abceb4dbbe3025ac525abc4");
        //form.AddField("client_secret", "abcd1234");
        //form.AddField("countryCode", "1");
        //form.AddField("mobile", "9876513214");
        //form.AddField("email", "seria1@mailinator.com");
        //form.AddField("password", "123456");


        form.AddField("client_id", "5abceb4dbbe3025ac525abc4");
        form.AddField("client_secret", "abcd1234");
        form.AddField("countryCode", "1");
        form.AddField("mobile", mobile);
        form.AddField("email", email);
        form.AddField("password", password);


        UnityWebRequest www = UnityWebRequest.Post(URL_REGISTER, form);

        www.chunkedTransfer = false;
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        } else {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload complete!");

            JsonData jsonvale1 = JsonMapper.ToObject(www.downloadHandler.text);
            Debug.Log(jsonvale1);

            callback(jsonvale1);
        }

        //WWW www = new WWW(URL_REGISTER, form);

        //yield return www;

        //if (string.IsNullOrEmpty(www.error) == false) {
        //    Debug.Log("WWW Error: " + www.error);
        //    Debug.Log("WWW Text: " + www.text);
        //} else {
        //    // No Error
        //    Debug.Log("WWW Text: " + www.text);
        //}

    }
    

    public IEnumerator LoginUser(string usrName, string psw, System.Action<JsonData> callback) {

        WWWForm form = new WWWForm();
        Debug.Log(usrName);
        Debug.Log(psw);

        form.AddField("client_id", "5abceb4dbbe3025ac525abc4");
        form.AddField("client_secret", "abcd1234");
        form.AddField("grant_type", "password");
        form.AddField("username", usrName);
        form.AddField("password", psw);

      

        UnityWebRequest www = UnityWebRequest.Post(URL_LOGIN, form);

        www.chunkedTransfer = false;
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError) {
            Debug.Log(www.error);
            
        } else {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload complete!");

            JsonData jsonvale1 = JsonMapper.ToObject(www.downloadHandler.text);
            Debug.Log(jsonvale1);

            callback(jsonvale1);
        }

    }

    public IEnumerator UpdateProfile(string profession , string travelDistance , string city ,string zipCode, System.Action<JsonData> callback) {
        string AcessToken = WebServiceHndlr.Ins.token_type+" "+ WebServiceHndlr.Ins.acess_token;
        Dictionary<string, string> headers = new Dictionary< string ,  string >();
        headers.Add("Authorization", AcessToken);
        WWWForm form = new WWWForm();
        form.AddField("client_id", "5abceb4dbbe3025ac525abc4");
        form.AddField("client_secret", "abcd1234");
        form.AddField("profession", profession);
        form.AddField("travelDistance", travelDistance);
        form.AddField("city", city);
        form.AddField("zipCode", zipCode);

        WWW www = new WWW (URL_SERVER, form.data , headers );

      
        yield return www;

        if (www.error != null) {
            Debug.Log(www.error);

            // After correction please remove . 
            JsonData jsonvale1 = JsonMapper.ToObject("");
            callback(jsonvale1);
            
        } else
        {
            Debug.Log(www.text.ToString());
            if (www.text.ToString() == "200")
            {
                Debug.Log(www.text);
                Debug.Log("Form upload complete!");

                JsonData jsonvale1 = JsonMapper.ToObject(www.text);
                Debug.Log(jsonvale1);

                callback(jsonvale1);
            }
        }
    }

    public IEnumerator GetProfile( string value) {

        //WWWForm form = new WWWForm();
        //form.AddField("status", status);
        Debug.Log("Enter");
        var headDict = new Dictionary<string, string>();
        headDict.Add("Authorization", value);//"[{"key":"","value":"","description":""}]")
     //   headDict.Add("description", "");
        

        WWW www = new WWW("http://138.68.1.23/user", null, headDict);

        yield return www;

        if (string.IsNullOrEmpty(www.error) == false) {
            Debug.Log("WWW Error: " + www.error);
            Debug.Log("WWW Text: " + www.text);

        } else
        {
            // No Error
            Debug.Log("WWW Text: " + www.text);
            JsonData jsonvale1 = JsonMapper.ToObject(www.text);
            Debug.Log(jsonvale1);
            parseJson parsejson;
            parsejson = new parseJson();
            GameManger.Instance.ProfileEmailID = jsonvale1["user"]["email"].ToString();
           GameManger.Instance.AgentProfileText.text = jsonvale1["user"]["email"].ToString();
            GameManger.Instance.DesignerProfileText.text = jsonvale1["user"]["email"].ToString();
            GameManger.Instance.VrPhotograoherText.text = jsonvale1["user"]["email"].ToString();
        }
    }

    public IEnumerator PutProfilePic() {

        var headDict = new Dictionary<string, string>();
        headDict.Add("Authorization", "Bearer 9Lr30VoBjPBQytxmGlcwUqb92gvolwx6Rf0W8TzPzamZe40T1ot8xByZRhC3vNrV");//"[{"key":"","value":"","description":""}]")
        headDict.Add("X-HTTP-Method-Override", "PUT");
        //headDict.Add("description", "");

        var bytes = new byte[1];

        WWW www = new WWW("http://138.68.59.251/user", bytes, headDict);

        yield return www;

        if (string.IsNullOrEmpty(www.error) == false) {
            Debug.Log("WWW Error: " + www.error);
            Debug.Log("WWW Text: " + www.text);
        } else {
            // No Error
            Debug.Log("WWW Text: " + www.text);
        }
    }

    public IEnumerator VerificationPhoneno(string mobileNo,
                             System.Action<JsonData> callback)
    {

        WWWForm form = new WWWForm();



        form.AddField("client_id", "5abceb4dbbe3025ac525abc4");
        form.AddField("client_secret", "abcd1234");
       
        form.AddField("mobile", mobileNo);
       


        UnityWebRequest www = UnityWebRequest.Post(URL_RESEND, form);

        www.chunkedTransfer = false;
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload complete!");

            JsonData jsonvale1 = JsonMapper.ToObject(www.downloadHandler.text);
            Debug.Log(jsonvale1);

            callback(jsonvale1);
        }


    }

    public IEnumerator VerificationCode(string mobileNo, string verificationCode,
                         System.Action<JsonData> callback)
    {

        WWWForm form = new WWWForm();



        form.AddField("client_id", "5abceb4dbbe3025ac525abc4");
        form.AddField("client_secret", "abcd1234");
        form.AddField("mobile", mobileNo);
        form.AddField("otpCode", verificationCode);



        UnityWebRequest www = UnityWebRequest.Post(URL_VERIFYOPT, form);

        www.chunkedTransfer = false;
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload complete!");

            JsonData jsonvale1 = JsonMapper.ToObject(www.downloadHandler.text);
            Debug.Log(jsonvale1);
           
            callback(jsonvale1);
        }


    }

    public IEnumerator forgotPassword(string mobileNo,
                     System.Action<JsonData> callback)
    {

        WWWForm form = new WWWForm();



        form.AddField("client_id", "5abceb4dbbe3025ac525abc4");
        form.AddField("client_secret", "abcd1234");
        form.AddField("mobile", mobileNo);
       

        UnityWebRequest www = UnityWebRequest.Post(URL_FORGETPASSWORD, form);

        www.chunkedTransfer = false;
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
            Debug.Log(www.downloadHandler.text);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            Debug.Log("Form upload complete!");

            JsonData jsonvale1 = JsonMapper.ToObject(www.downloadHandler.text);
            Debug.Log(jsonvale1);

            callback(jsonvale1);
        }


    }

    public IEnumerator Getlistings()
    {

        //WWWForm form = new WWWForm();
        //form.AddField("status", status);
        Debug.Log("Enter");
        var headDict = new Dictionary<string, string>();
        headDict.Add("Authorization", "Bearer R08lihG88kDDGUHztjEzK1S5X20HMrgLyNy8oe6aorJQ5eOI3vNxrGqhycxvNfX0");//"[{"key":"","value":"","description":""}]")
                                                                                                                 //   headDict.Add("description", "");


        WWW www = new WWW("http://138.68.1.23/listing", null, headDict);

        yield return www;

        if (string.IsNullOrEmpty(www.error) == false)
        {
            Debug.Log("WWW Error: " + www.error);
            Debug.Log("WWW Text: " + www.text);
        }
        else
        {
            // No Error
            Debug.Log("WWW Text: " + www.text);
            JsonData jsonvale1 = JsonMapper.ToObject(www.text);
            Debug.Log(jsonvale1);
            parseJson parsejson;
            parsejson = new parseJson();
            Debug.Log(jsonvale1["listings"].Count);
            BuyingList.NoOfElements = int.Parse(jsonvale1["listings"].Count.ToString());
            BuyingList.ListData();
            for (int i = 0; i < BuyingList.NoOfElements; i++)
            {
                BuyingList.BuyData[i]._id = jsonvale1["listings"][i]["_id"].ToString();
                BuyingList.BuyData[i].updatedAt = jsonvale1["listings"][i]["updatedAt"].ToString();
                BuyingList.BuyData[i].createdAt = jsonvale1["listings"][i]["createdAt"].ToString();
                BuyingList.BuyData[i].ownerId = jsonvale1["listings"][i]["ownerId"].ToString();
                BuyingList.BuyData[i].address = jsonvale1["listings"][i]["address"].ToString();
                BuyingList.BuyData[i].country = jsonvale1["listings"][i]["country"].ToString();
                BuyingList.BuyData[i].zip = jsonvale1["listings"][i]["zip"].ToString();
                BuyingList.BuyData[i].squareFeet = jsonvale1["listings"][i]["squareFeet"].ToString();
                BuyingList.BuyData[i].bed = jsonvale1["listings"][i]["bed"].ToString();
                BuyingList.BuyData[i].bath = jsonvale1["listings"][i]["bath"].ToString();
                BuyingList.BuyData[i].sellOrRent = jsonvale1["listings"][i]["sellOrRent"].ToString();
                BuyingList.BuyData[i].price = jsonvale1["listings"][i]["price"].ToString();
                BuyingList.BuyData[i].rentalAmount = jsonvale1["listings"][i]["rentalAmount"].ToString();

               
                //    BuyingList.BuyData[i].homeTheatre = jsonvale1["listings"][i]["homeTheatre"].ToString();

            //    BuyingList.BuyData[i].status = jsonvale1["listings"][i]["status"].ToString();
                BuyingList.BuyData[i].information = jsonvale1["listings"][i]["information"].ToString();
                int NoOfDate = int.Parse(jsonvale1["listings"][i]["appointmentDates"].Count.ToString());

                BuyingList.appointmentDates = new buyingListData.appointmentDatesContainer[NoOfDate];

                for (int j = 0; j < NoOfDate; j++)
                {
               //     BuyingList.appointmentDates[j].date = jsonvale1["listings"][i]["appointmentDates"][j]["date"].ToString();
                //    BuyingList.appointmentDates[j].preferedTime = jsonvale1["listings"][i]["appointmentDates"][j]["preferedTime"].ToString();
                }
                BuyingList.BuyData[i].__v = jsonvale1["listings"][i]["__v"].ToString();
                BuyingList.BuyData[i].owner._id = jsonvale1["listings"][i]["owner"]["_id"].ToString();
                BuyingList.BuyData[i].owner.updatedAt = jsonvale1["listings"][i]["owner"]["updatedAt"].ToString();
                BuyingList.BuyData[i].owner.createdAt = jsonvale1["listings"][i]["owner"]["createdAt"].ToString();
                BuyingList.BuyData[i].owner.email = jsonvale1["listings"][i]["owner"]["email"].ToString();
                BuyingList.BuyData[i].owner.countryCode = jsonvale1["listings"][i]["owner"]["countryCode"].ToString();
          //      BuyingList.BuyData[i].owner.mobile = jsonvale1["listings"][i]["owner"]["mobile"].ToString();
                BuyingList.BuyData[i].owner.password = jsonvale1["listings"][i]["owner"]["password"].ToString();

             //   int NoOfacceptedListingIds = int.Parse( jsonvale1["listings"][i]["owner"]["acceptedListingIds"].Count.ToString());
            //    BuyingList.BuyData[i].owner.acceptedListingIds = new string[NoOfacceptedListingIds];
            //    for (int k = 0; k < NoOfacceptedListingIds; k++)
           //     {

           //     BuyingList.BuyData[i].owner.acceptedListingIds[k] = jsonvale1["listings"][i]["owner"]["acceptedListingIds"][k].ToString();
            //    }

                //int favoriteListingIds = int.Parse(jsonvale1["listings"][i]["owner"]["favoriteListingIds"].Count.ToString());
                //BuyingList.BuyData[i].owner.favoriteListingIds = new string[favoriteListingIds];

                //for (int l = 0; l < favoriteListingIds; l++)
                //{

                //    BuyingList.BuyData[i].owner.favoriteListingIds[l] = jsonvale1["listings"][i]["owner"]["favoriteListingIds"][l].ToString();
                //}
                BuyingList.BuyData[i].owner.isMobileVerified = jsonvale1["listings"][i]["owner"]["isMobileVerified"].ToString();
                BuyingList.BuyData[i].owner.__v = jsonvale1["listings"][i]["owner"]["__v"].ToString();


             //   BuyingList.BuyData[i].owner.otpCode = jsonvale1["listings"][i]["owner"]["otpCode"].ToString();
              //  BuyingList.BuyData[i].owner.otpCodeTimeStamp = jsonvale1["listings"][i]["owner"]["otpCodeTimeStamp"].ToString();

                BuyingList.BuyData[i].owner.basecity = jsonvale1["listings"][i]["owner"]["basecity"].ToString();

                BuyingList.BuyData[i].owner.distanceWillingToTravel.distance = jsonvale1["listings"][i]["owner"]["distanceWillingToTravel"]["distance"].ToString();
             //   BuyingList.BuyData[i].owner.distanceWillingToTravel.unit = jsonvale1["listings"][i]["owner"]["distanceWillingToTravel"]["unit"].ToString();

                BuyingList.BuyData[i].owner.linkToPortfolio = jsonvale1["listings"][i]["owner"]["linkToPortfolio"].ToString();
                BuyingList.BuyData[i].owner.name = jsonvale1["listings"][i]["owner"]["name"].ToString();
       //         BuyingList.BuyData[i].owner.profession = jsonvale1["listings"][i]["owner"]["profession"].ToString();
          //      BuyingList.BuyData[i].owner.realEstateLicenseNumber = jsonvale1["listings"][i]["owner"]["realEstateLicenseNumber"].ToString();
                BuyingList.BuyData[i].owner.zip = jsonvale1["listings"][i]["owner"]["zip"].ToString();

                try
                {
                 //   BuyingList.BuyData[i].owner.profilePhotoUrl = jsonvale1["listings"][i]["owner"]["profilePhotoUrl"].ToString();
                }
                catch (System.Exception e)
                {
                    Debug.LogException(e, this);
                }
               
                

                BuyingList.BuyData[i].isFavorite = jsonvale1["listings"][i]["isFavorite"].ToString();
            }
        }
    }
}
public class parseJson
{
    public string id;
    public string sap_code;
    public string name;
    public string email;
    public string mobile_no;
    public string center_name;
    public string city;
    public string zone;
    public string country;
    public string created_by;
    public string created_at;
    public string updated_at;
    public string CenterName;
    public string termAndCondition;
    public string flag;
    public string AutID;

}


