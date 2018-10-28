using UnityEngine.UI;
using UnityEngine;

public class TextSpaceing : MonoBehaviour {
    public InputField VarificationCode;
    public Text[] TextFileds;

	void Update () {
        Debug.Log("Varificartion code " +  VarificationCode.text);
        if (VarificationCode.text.Length == 1)
        {
           TextFileds[0].text = VarificationCode.text; ;
        }
        if (VarificationCode.text.Length == 2)
        {
            char  t = VarificationCode.text[1];
            TextFileds[1].text =t.ToString(); 
        }
         if (VarificationCode.text.Length == 3)
        {
            char t = VarificationCode.text[2];
            TextFileds[2].text = t.ToString();
        }
        if (VarificationCode.text.Length == 4)
        {
            char t = VarificationCode.text[3];
            TextFileds[3].text = t.ToString();
        }
      
    }
}
