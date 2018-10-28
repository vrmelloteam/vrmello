using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginSceneMgr : MonoBehaviour {

    public GameObject RegisterPopup;
    public GameObject LoginPopup;
    public GameObject ForgotPasswordPopup;
    public GameObject MobileVerificationPopup;
    public GameObject EnterverificationCode;

    public InputField SingupEmail;
    public InputField SingupPassword;
    public InputField SingupPhone;
   
    public InputField MobileNo;
    public InputField verificationCodeField;
    
    public enum LoginScenePopupType
    {
        RegisterPopup,
        LoginPopup,
        ForgotPasswordPopup,
        MobileVerificationPopup,
        EnterverificationCode
    }

  

    void ShowPopup(LoginScenePopupType popupType) {
        HideAllPopups();

        switch (popupType)
        {
            case LoginScenePopupType.RegisterPopup:
                RegisterPopup.SetActive(true);
                break;

            case LoginScenePopupType.LoginPopup:
                LoginPopup.SetActive(true);
                break;

            case LoginScenePopupType.ForgotPasswordPopup:
                ForgotPasswordPopup.SetActive(true);
                break;

            case LoginScenePopupType.MobileVerificationPopup:
                MobileVerificationPopup.SetActive(true);
                break;

            case LoginScenePopupType.EnterverificationCode:
                EnterverificationCode.SetActive(true);
                break;

            default:
                break;
        }

       /* if (popupTyp == LoginScenePopupType.RegisterPopup) {
            RegisterPopup.SetActive(true);
        } else if (popupTyp == LoginScenePopupType.LoginPopup) {
            LoginPopup.SetActive(true);
        } else if (popupTyp == LoginScenePopupType.MobileVerificationPopup) {
            MobileVerificationPopup.SetActive(true);
        }
        else if (popupTyp == LoginScenePopupType.EnterverificationCode)
        {
            EnterverificationCode.SetActive(true);
        }*/

    }

    void HideAllPopups() {
        RegisterPopup.SetActive(false);
        LoginPopup.SetActive(false);
        ForgotPasswordPopup.SetActive(false);
        MobileVerificationPopup.SetActive(false);
    }

    // Use this for initialization
    void Start () {
        Screen.orientation = ScreenOrientation.Portrait;
        StartCoroutine(SwitchTo2D());
        if (PlayerPrefs.HasKey("Singup"))
        {
            string value = PlayerPrefs.GetString("Singup");
            if (value == "true")
            {
                ShowPopup(LoginScenePopupType.LoginPopup);
            }
        }
        else
        {
        ShowPopup(LoginScenePopupType.RegisterPopup);
        }
     
    }

    IEnumerator loadDevice(string newDevice) {
        UnityEngine.XR.XRSettings.LoadDeviceByName(newDevice);
        yield return null;
        UnityEngine.XR.XRSettings.enabled = false;
    }

    // Call via StartCoroutine (SwitchTo2D()) from your code.Or, use 
    // yield SwitchTo2D() if calling from inside another coroutine.


    IEnumerator SwitchTo2D() {
        // Empty string loads the "None" device.

        UnityEngine.XR.XRSettings.LoadDeviceByName("");
        // Must wait one frame after calling "XRSetting.LoadDeviceByName

        yield return null;

        UnityEngine.XR.XRSettings.enabled = false;
        // not needed , since loading the none ("" ) device takes care of this.
        //XRSetting.enable = false;
        // Restore 2D camera setting.
        ResetCameras();
    }

    // Resets camera transform and setting on all enabled eyes cameras.
    private void ResetCameras()
    {
        // camera looping logic copies from GvrEditorEmulator.cs.
        for (int i = 0; i < Camera.allCameras.Length; i++)
        {
            Camera cam = Camera.allCameras[i];
            if (cam.enabled && cam.stereoTargetEye != StereoTargetEyeMask.None) {
                //Rest local position.
                //only required if you change the camera's local position while in 2D mode 

                cam.transform.localPosition = Vector3.zero;

                //Reset local rotaton
                // only required if you change the camera's local rotation while in 2d mode.

                cam.transform.localRotation = Quaternion.identity;

                // No longer needed , see issue github.com/googleve 
                // cam.RestAspect();

            // No need to rest filedOfView , Since it's reset automatically
            }
        }
    }

    string Status;
    string SucessMsg;
    public void btnRegisterClicked() {
        StartCoroutine(WebServiceHndlr.Ins.RegisterUser(SingupEmail.text, SingupPhone.text, SingupPassword.text, jsonData => {

          //  Status = jsonData["status"].ToString();
            SucessMsg = jsonData["message"].ToString();


            if (SucessMsg == "Registration successful. We have sent a One Time Password to your mobile number for verification") {
                // Common.Client_ID = jsonData["Client_ID"].ToString();
                PlayerPrefs.SetString("MobileNo", MobileNo.text);
                //Show Mobile Verification Popup
                ShowPopup(LoginScenePopupType.EnterverificationCode);
            }

        }));
      //  ShowPopup(LoginScenePopupType.MobileVerificationPopup);
        //StartCoroutine(WebServiceHndlr.Ins.GetProfile());
        //StartCoroutine(WebServiceHndlr.Ins.PutProfilePic());
    }

    public InputField LoginUserName;
    public InputField LoginePassword;
    public void btnLoginClicked() {

        StartCoroutine(WebServiceHndlr.Ins.LoginUser(LoginUserName.text, LoginePassword.text, jsonData => {
   

            
                Common.access_token = jsonData["access_token"].ToString();
                Common.token_type = jsonData["token_type"].ToString();

                //Load BuySell Scene
                SceneManager.LoadScene("MainScene");
           
           
           

        }));
       
    }

    public void ShowForgetPasswordPopUP()
    {
        ShowPopup(LoginScenePopupType.ForgotPasswordPopup);
    }

    public void btnForgotPasswordClicked()

    {
        StartCoroutine(WebServiceHndlr.Ins.forgotPassword(MobileNo.text, jsonData => {


            SucessMsg = jsonData["message"].ToString();


            if (SucessMsg == "We have sent a One Time Password to your mobile number for resetting password")
            {
               // Common.Client_ID = jsonData["Client_ID"].ToString();

                //Show Mobile Verification Popup
                ShowPopup(LoginScenePopupType.LoginPopup);
            }

        }));

       
    }

    public void btnVerifiedClicked()
    {
        StartCoroutine(WebServiceHndlr.Ins.VerificationPhoneno(MobileNo.text, jsonData => {


            SucessMsg = jsonData["message"].ToString();


            if (SucessMsg == "We have sent a One Time Password to your mobile number for verification")
            {
                Common.client_id = jsonData["Client_ID"].ToString();

                //Show Mobile Verification Popup
                ShowPopup(LoginScenePopupType.EnterverificationCode);
            }

        }));

     //   ShowPopup(LoginScenePopupType.EnterverificationCode);
    }

    public void btnEnterVerifiedClicked()
    {
        StartCoroutine(WebServiceHndlr.Ins.VerificationCode(MobileNo.text, verificationCodeField.text, jsonData => {


            SucessMsg = jsonData["message"].ToString();


            if (SucessMsg == "Your mobile number verified successfully")
            {
               // Common.Client_ID = jsonData["Client_ID"].ToString();

                //Show Mobile Verification Popup
                PlayerPrefs.SetString("Singup", "true");
                SceneManager.LoadScene("BuySellScene");
            }

        }));
      //  SceneManager.LoadScene("BuySellScene");
    }

    public void ShowLogin()
    {
      //  MobileVerificationPopup.SetActive(false);
      //  LoginPopup.SetActive(true);
        ShowPopup(LoginScenePopupType.LoginPopup);
    }

    public void ShowSignUp()
    {
        ShowPopup(LoginScenePopupType.RegisterPopup);
    }
    public void loadsecen() {

        SceneManager.LoadScene("BuySellScene");

    }
}
