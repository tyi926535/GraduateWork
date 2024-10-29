using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainEntranceAdmin : MonoBehaviour
{
    
    public InputField textName;
    public InputField textPassw;
    public GameObject ErrorName1;
    public GameObject ErrorName2;
    public GameObject Entrance;

    public void Debager2()
    {
        int attempts = 0;
        var allDatabaseChangeableParameters = Resources.LoadAll<BDAdmin>("ADMIN");
        var selectedOption = allDatabaseChangeableParameters[0];
        string tName = textName.text;
        string tPas = textPassw.text;
        string str = "";
        foreach (char r in tPas)
        {
            if (r != ' ') { str += r; }
        }
        tPas = str;
        str = "";
        foreach (char r in tName)
        {
            if (r != ' ') { str += r; }
        }
        tName = str;
        ErrorName1.SetActive(false);
        ErrorName2.SetActive(false);
        if (tName == "") { ErrorName1.SetActive(true); attempts++; }
        else
        {
            if (tName != selectedOption.LoginAd) { ErrorName1.SetActive(true); attempts++; }
            else
            {
                if (tPas == "") { ErrorName2.SetActive(true); attempts++; }
                else
                {
                    if (tPas != selectedOption.PasswordAd) { ErrorName2.SetActive(true); attempts++; }
                }
            }
        }

        if (attempts > 2)
        {
            Exit2();
        }
        if (attempts == 0)
        {
            ModeSelection();
        }

    }

    private void ModeSelection()
    {
        Entrance.SetActive(false);
        textPassw.text = string.Empty;
        textName.text = string.Empty;
    }
    public void Exit2()
    {
        Application.Quit();
    }
}
