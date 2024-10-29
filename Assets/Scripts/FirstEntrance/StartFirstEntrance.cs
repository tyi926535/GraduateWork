using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartFirstEntrance : MonoBehaviour
{
    // Start is called before the first frame update
    public void MenuAdmin()
    {
        SceneManager.LoadScene("MenuAdmin");


    }
    public void MenuUser()
    {
        var allDatabaseChangeableParameters = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption = allDatabaseChangeableParameters[0];

       

        SceneManager.LoadScene("Menu");
    }

    
}
