using System.Collections;//динамические массивы
using System.Collections.Generic;
using UnityEngine;//стандартные классы
using UnityEngine.UI;
using System.IO;
using System;
using static Unity.IO.LowLevel.Unsafe.AsyncReadManagerMetrics;


public class StartMenu : MonoBehaviour
{
    
    public GameObject Entrance;//////////////////////////////////////
    public GameObject ErrorEntr;

    void Start()//выполняется при старте игры
    {
        int flag = 0;
        flag = AccessPoint.chekingNull();
        if (flag==0)
        {
            Entrance.SetActive(false);
            ErrorEntr.SetActive(true);
        }
        else
        {
            
            //var selectedOption = (DataBaseTime)ScriptableObject.CreateInstance(typeof(DataBaseTime));

            if (PlayerPrefs.HasKey("idUser")==false ) 
            {
                Entrance.SetActive(true);
                ErrorEntr.SetActive(false);
            }
            else
            {
                Entrance.SetActive(false);
                ErrorEntr.SetActive(false);
                var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
                var selectedOption = allDatabaseChangeableParameters[0];
                selectedOption.idUser = PlayerPrefs.GetInt("idUser");
                selectedOption.levelWas= PlayerPrefs.GetInt("levelWas");
            }
        }
    }
    public void ExitOne()
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption = allDatabaseChangeableParameters[0];
        selectedOption.idUser = 0;
        selectedOption.levelWas = 0;
        selectedOption.dataNow = "";
        PlayerPrefs.DeleteKey("idUser");
        PlayerPrefs.DeleteKey("levelWas");
        Application.Quit();
    }
    private void OnApplicationQuit()
    {
    }
}
