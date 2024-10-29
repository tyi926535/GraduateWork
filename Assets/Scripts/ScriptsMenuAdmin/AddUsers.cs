using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using System.IO;
using System;

public class AddUsers : MonoBehaviour
{
    public InputField tF;
    public InputField tN;
    public InputField tG;
    public GameObject ErrorName1;
    public GameObject ErrorName2;
    public GameObject ErrorName3;
    public GameObject MenuAddUsers;
    

    public void Debager()
    {
        var rName = tN.text;
        string str = "";
        foreach (var t in rName)
        {
            if(t!=' ') { str += t; }
        }
        rName = str;
        var rFam = tF.text;
        str = "";
        foreach (var t in rFam)
        {
            if(t!=' ') { str += t; }
        }
        rFam = str;
        var rGroup = tG.text;
        str = "";
        foreach (var t in rGroup)
        {
            if (t != ' ') { str += t; }
        }
        rGroup = str;

        ErrorName1.SetActive(false);
        ErrorName2.SetActive(false);
        ErrorName3.SetActive(false);
        if ((rName == "") || (rFam == "")) { ErrorName1.SetActive(true); }
        else
        {
            if (rGroup == "") { ErrorName3.SetActive(true); }
            else
            {
                int vb = 0;
                vb = AccessPoint.UserSearch2( rFam,rName, rGroup);

                if (vb > 0) { ErrorName2.SetActive(true); }
                else
                {
                    string[] str4 = new string[3];
                    str4[1] = rName;
                    str4[0] = rFam;
                    str4[2] = rGroup;
                    AccessPoint.addUser(str4);

                    RewriteText();

                }
            }
        }
    }
    public void RewriteText()//Переписывание файла
    {
        tN.text = string.Empty;
        tF.text = string.Empty;
        tG.text = string.Empty;

        ErrorName1.SetActive(false);
        ErrorName2.SetActive(false);
        ErrorName3.SetActive(false);
        MenuAddUsers.SetActive(false);
    }

}
