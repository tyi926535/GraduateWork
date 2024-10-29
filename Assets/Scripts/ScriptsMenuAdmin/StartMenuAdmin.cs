using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenuAdmin : MonoBehaviour
{
    public GameObject Entrance;//////////////////////////////////////
    public GameObject ErrorEntr;

    void Start()//выполняется при старте игры
    {
        int flag = -1;
        flag = AccessPoint.chekingNull();
        if (flag == -1)
        {
            Entrance.SetActive(false);
            ErrorEntr.SetActive(true);
        }
        else
        {
            Entrance.SetActive(true);
            ErrorEntr.SetActive(false);
        }
        var allDatabaseChangeableParameters = Resources.LoadAll<BDAdmin>("ADMIN");
        var selectedOption = allDatabaseChangeableParameters[0];
        if (PlayerPrefs.HasKey("LoginAd") == false)
        {
            selectedOption.LoginAd = "Admin";
            PlayerPrefs.SetString("LoginAd", "Admin");
        }
        if (PlayerPrefs.HasKey("PasswordAd") == false)
        {
            selectedOption.PasswordAd = "123";
            PlayerPrefs.SetString("PasswordAd", "123");
        }

        if (PlayerPrefs.HasKey("LoginAd") == true)
        {
            selectedOption.LoginAd =  PlayerPrefs.GetString("LoginAd");
        }
        if (PlayerPrefs.HasKey("PasswordAd") == true)
        {
            selectedOption.PasswordAd = PlayerPrefs.GetString("PasswordAd");
        }
    }
    public void OnDestroy()
    {
        Application.Quit();
    }

}
