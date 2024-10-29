using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AdapterScene : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject noTask;
    public void StartScene()
    {
       var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
       var selectedOption = allDatabaseChangeableParameters[0];

        System.DateTime CurrentTime = DateTime.Now;
        string[] fil = new string[3];
        fil[0] = selectedOption.idUser.ToString();
        fil[1] = selectedOption.levelWas.ToString();
        fil[2] = CurrentTime.Hour + ":" + CurrentTime.Minute + ","+CurrentTime.Day + "." + CurrentTime.Month + "." + CurrentTime.Year;
        selectedOption.dataNow = fil[2];
        AccessPoint.UpdateBD(fil);
        PlayerPrefs.SetInt("idUser", Convert.ToInt32(fil[0]));
        PlayerPrefs.SetInt("levelWas", Convert.ToInt32(fil[1]));
        if (selectedOption.levelWas==0)
        {
            //SceneManager.LoadScene("Level1",LoadSceneMode.Additive);
            SceneManager.LoadScene("Level1");
        }
        if (selectedOption.levelWas == 1)
        {
            SceneManager.LoadScene("Level2");
        }
        if (selectedOption.levelWas == 2)
        {
            SceneManager.LoadScene("Level3");
        }
        if  (selectedOption.levelWas == 3)
        {
            SceneManager.LoadScene("Level4");
        }
        if (selectedOption.levelWas == 4)
        {
            noTask.SetActive(true);
        }
    }
    public void MenuScene()
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption = allDatabaseChangeableParameters[0];

        System.DateTime CurrentTime = DateTime.Now;
        string[] fil = new string[3];
        fil[0] = selectedOption.idUser.ToString();
        fil[1] = selectedOption.levelWas.ToString();
        fil[2] = CurrentTime.Hour + ":"+CurrentTime.Minute + ","+CurrentTime.Day + "." + CurrentTime.Month + "." + CurrentTime.Year;
        selectedOption.dataNow = fil[2];
        PlayerPrefs.SetInt("idUser", Convert.ToInt32(fil[0]));
        PlayerPrefs.SetInt("levelWas", Convert.ToInt32(fil[1]));

        SceneManager.LoadScene("Menu");
        //SceneManager.LoadScene("Menu", LoadSceneMode.Single);

    }
    public void Scene4()
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption = allDatabaseChangeableParameters[0];

        System.DateTime CurrentTime = DateTime.Now;
        string[] fil = new string[3];
        fil[0] = selectedOption.idUser.ToString();
        fil[1] = "3";
        fil[2] = CurrentTime.Hour + ":" + CurrentTime.Minute + "," + CurrentTime.Day + "." + CurrentTime.Month + "." + CurrentTime.Year;
        selectedOption.dataNow = fil[2];
        selectedOption.levelWas = 3;
        PlayerPrefs.SetInt("idUser", Convert.ToInt32(fil[0]));
        PlayerPrefs.SetInt("levelWas", Convert.ToInt32(fil[1]));

        AccessPoint.UpdateBD(fil);
        SceneManager.LoadScene("Level4");

    }
    public void Final(GameObject Panel)
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption = allDatabaseChangeableParameters[0];

        System.DateTime CurrentTime = DateTime.Now;
        string[] fil = new string[3];
        fil[0] = selectedOption.idUser.ToString();
        fil[1] = "4";
        fil[2] = CurrentTime.Hour + ":" + CurrentTime.Minute + "," + CurrentTime.Day + "." + CurrentTime.Month + "." + CurrentTime.Year;
        selectedOption.dataNow = fil[2];
        selectedOption.levelWas = 4;

        PlayerPrefs.SetInt("idUser", Convert.ToInt32(fil[0]));
        PlayerPrefs.SetInt("levelWas", Convert.ToInt32(fil[1]));
        AccessPoint.UpdateBD(fil);
        Panel.SetActive(true);

    }
    public void Scene2()
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption = allDatabaseChangeableParameters[0];

        System.DateTime CurrentTime = DateTime.Now;
        string[] fil = new string[3];
        fil[0] = selectedOption.idUser.ToString();
        fil[1] = "1";
        fil[2] = CurrentTime.Hour + ":" + CurrentTime.Minute + "," + CurrentTime.Day + "." + CurrentTime.Month + "." + CurrentTime.Year;
        selectedOption.dataNow = fil[2];
        selectedOption.levelWas = 1;
        PlayerPrefs.SetInt("idUser", Convert.ToInt32(fil[0]));
        PlayerPrefs.SetInt("levelWas", Convert.ToInt32(fil[1]));

        SceneManager.LoadScene("Level2");
    }
    public void Scene3()
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption = allDatabaseChangeableParameters[0];

        System.DateTime CurrentTime = DateTime.Now;
        string[] fil = new string[3];
        fil[0] = selectedOption.idUser.ToString();
        fil[1] = "2";
        fil[2] = CurrentTime.Hour + ":" + CurrentTime.Minute + "," + CurrentTime.Day + "." + CurrentTime.Month + "." + CurrentTime.Year;
        selectedOption.dataNow = fil[2];
        selectedOption.levelWas = 2;
        PlayerPrefs.SetInt("idUser", Convert.ToInt32(fil[0]));
        PlayerPrefs.SetInt("levelWas", Convert.ToInt32(fil[1]));

        SceneManager.LoadScene("Level3");
    }

}
