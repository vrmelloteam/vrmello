using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoFillMobileNo : MonoBehaviour {

    public InputField MobileNoField;
    public void OnEnable()
    {
        MobileNoField.text = PlayerPrefs.GetString("MobileNo");
    }
}
