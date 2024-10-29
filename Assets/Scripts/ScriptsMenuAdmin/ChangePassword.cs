using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using Unity.VisualScripting;
using System.ComponentModel;

public class ChangePassword : MonoBehaviour
{
    // Start is called before the first frame update
    public InputField TP;
    public InputField TPN;
    public InputField TLN;
    public GameObject Error1;
    public GameObject Window1;
    public void ComparisonPassword()
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<BDAdmin>("ADMIN");
        var selectedOption = allDatabaseChangeableParameters[0];
        string pasNow=selectedOption.PasswordAd;

        string tp1 = TP.text;
        string tpn1 = TPN.text;
        string tln = TLN.text;
        string str = "";
        foreach(char r in tp1)
        {
            if(r!=' ') { str += r; }
        }
        tp1 = str;
        str = "";
        foreach (char r in tpn1)
        {
            if (r != ' ') { str += r; }
        }
        tpn1 = str;
        str = "";
        foreach (char r in tln)
        {
            if (r != ' ') { str += r; }
        }
        tln = str;
        
        Error1.SetActive(false);
        if (tp1 != pasNow) { Error1.SetActive(true); }
        else
        {
            selectedOption.PasswordAd = tpn1;
            PlayerPrefs.SetString("PasswordAd", tpn1);

            if (tln != "") { selectedOption.LoginAd = tln; PlayerPrefs.SetString("LoginAd", tln); }
            RewriteText();
        }
    }

    public void RewriteText()//Переписывание файла
    {
        TP.text = string.Empty;
        TPN.text = string.Empty;
        TLN.text = string.Empty;
        Window1.SetActive(false);
    }


}
