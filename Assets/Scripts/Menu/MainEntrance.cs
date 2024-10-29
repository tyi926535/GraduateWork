using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using System.IO;
using System;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;

public class MainEntrance : MonoBehaviour
{
    // Start is called before the first frame update

    
    public InputField textName;
    public InputField textFam;
    public InputField textGroup;
    public GameObject ErrorName1;
    public GameObject Entrance;

    public void Debager2()
    {   
        int attempts = 0;
        string tName = textName.text;
        string tFam = textFam.text;
        string tGroup= textGroup.text;
        string textR = "";
        foreach (char r in tFam)
        {
            if (r != ' ') { textR += r; }
        }
        tFam= textR;
        textR = "";
        foreach (char r in tName)
        {
            if (r != ' ') { textR += r; }
        }
        tName = textR;
        textR = "";
        foreach (char r in tGroup)
        {
            if (r != ' ') { textR += r; }
        }
        tGroup = textR;
        string[] fil=new string[3];
        fil =AccessPoint.UserSearch(tName, tFam, tGroup);

        // fil[0]--id  fil[1]--level  fil[2]--data 
        if ((fil[0] == "")|| (fil[1] == "")|| (fil[2] == "")) { ErrorName1.SetActive(true); attempts++; }
        else
        {
            ErrorName1.SetActive(false); ErrorName1.SetActive(false);
            System.DateTime CurrentTime = DateTime.Now;
            var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
            var selectedOption = allDatabaseChangeableParameters[0];
            //var selectedOption = (DataBaseTime)ScriptableObject.CreateInstance(typeof(DataBaseTime));
            PlayerPrefs.SetInt("idUser", Convert.ToInt32(fil[0]));
            PlayerPrefs.SetInt("levelWas", Convert.ToInt32(fil[1]));
            selectedOption.idUser = Convert.ToInt32(fil[0]);
            selectedOption.levelWas = Convert.ToInt32(fil[1]);
            fil[2]= CurrentTime.Day + "." + CurrentTime.Month + "." + CurrentTime.Year;
            selectedOption.dataNow = fil[2];
            AccessPoint.UpdateBD(fil);
            ModeSelection();
        }
        if (attempts > 2)
        {
            Exit2();
        }

    }

    private void ModeSelection()
    {
        
        Entrance.SetActive(false);
        textName.text = string.Empty;
        textFam.text = string.Empty;


    }
    public void Exit2()
    {
        Application.Quit();
    }

}
