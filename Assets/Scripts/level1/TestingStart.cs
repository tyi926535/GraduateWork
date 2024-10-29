using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestingStart : MonoBehaviour
{
   public GameObject entranceGroup;
   public GameObject serverGroup;
   public GameObject error;
   public GameObject Constructor1;
   public GameObject Constructor2;
    public GameObject Testing1;
    public GameObject Testing2T;
    public GameObject Testing2F;
    public void CheckBeforeTest()
    {
        int counterEntrance = 0;
        foreach (Transform child in entranceGroup.transform)
        {
            var childs = child.name.Split('*');
            if (childs.Length > 1) { counterEntrance++; }
        }
        int serverEntrance = 0;
        foreach (Transform child in serverGroup.transform)
        {
            var childs = child.name.Split('*');
            if (childs.Length > 1) { serverEntrance++; }
        }
        if ((counterEntrance == 0) || (serverEntrance == 0))
        {
            error.SetActive(true);
        }
        else { GoToTestingSection();}
        
    }
    private void GoToTestingSection()
    {
        var allDatabaseChangeableParameters2 = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption0 = allDatabaseChangeableParameters2[0];
        var flagInt = Convert.ToInt32(selectedOption0.levelWas + 1);
        if (flagInt == 1) { Constructor1.SetActive(false);  Testing1.SetActive(true); }
        if (flagInt == 2) 
        {
            int serverGroup = 0;
            int queueGroup = 0;
            int connectionGroup = 0;
            int entranceGroup = 0;
            Constructor2.SetActive(false); 
            
            var allCommunications = Resources.LoadAll<Communications>("connection");
            for (int i = 0; i < 12; i++)
            {
                var selectedO2 = allCommunications[i];
                if (selectedO2.queue != null) { queueGroup++; }
                if (selectedO2.device != null)
                {
                    if (selectedO2.device.tag == "serverGroup") { serverGroup++; }
                    if (selectedO2.device.tag == "connectionGroup") { connectionGroup++; }
                    if (selectedO2.device.tag == "entranceGroup") { entranceGroup++; }
                }

            }
            
            if ((serverGroup== 2) && (queueGroup ==5) && (entranceGroup== 1)&& (connectionGroup == 2))
            {
                Testing2T.SetActive(true);
                Testing2F.SetActive(false);
            }
            else
            {
                Testing2F.SetActive(true);
                Testing2T.SetActive(false);
            }

        }

        
    }
}
