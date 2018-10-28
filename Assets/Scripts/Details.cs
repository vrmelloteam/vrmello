using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Details : MonoBehaviour {

    public Text Name;
    public Text Address;
    public Text BedNo;
    public Text BathroomNO;
    public Text Area;
    public Image Profiie;
    public Text Information;
    public RawImage VideoPlayer;

    private void OnEnable()
    {
        GameManger.Instance.buy.SetActive(false);
    }

    // Update is called once per frame
    void Update () {
		
	}
}
