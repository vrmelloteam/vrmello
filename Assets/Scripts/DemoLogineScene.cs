using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoLogineScene : MonoBehaviour {
    public GameObject[] Panals;
    public int IndexOf;

    public void SwitchPanals() {
        if (Panals.Length != IndexOf)
        {
            IndexOf++;
            Panals[IndexOf ].SetActive(true);

        }
        else {
            SceneManager.LoadScene("BuySellScene");
        }
    }
}
