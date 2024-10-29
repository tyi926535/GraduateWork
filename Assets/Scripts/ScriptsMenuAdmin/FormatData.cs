using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class FormatData : MonoBehaviour
{

    public GameObject Window2;
    public GameObject Conteiner;
    public GameObject Conteiner2;
    public GameObject Save;
    public GameObject update;
    public void FormatD()
    {

        Save.SetActive(false);
        update.SetActive(false);
        /*
        AccessPoint.DeleteBD();
        GameObject recod22 = Conteiner2.transform.Find("tpassword").gameObject;
        recod22.GetComponent<Text>().text="";


        List<GameObject> usersChild = new List<GameObject>();
        for (int i = 0; i < Conteiner.transform.childCount; i++)
        {
            usersChild.Add(Conteiner.transform.GetChild(i).gameObject);
        }
        int r = 0;
        foreach (var t in usersChild)
        {
            { Destroy(t); }
            r++;

        }
        */

    }
    
}
