using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel3 : MonoBehaviour
{
 
    void Start()
    {

        var allDatabaseChangeableParameters1 = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption1 = allDatabaseChangeableParameters1[0];
        selectedOption1.idUser = PlayerPrefs.GetInt("idUser");
        selectedOption1.levelWas = PlayerPrefs.GetInt("levelWas");
        var allDCP = Resources.LoadAll<PercentageRatio>("level3");
        for (int i = 0; i < 12; i++)
        {
            var sOpt = allDCP[i];
            sOpt.numberPeople = 0;
        }
        
    }

    
}
