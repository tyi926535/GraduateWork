using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ListUsers : MonoBehaviour
{
    public GameObject conteiner;
    public GameObject conteiner1;
    public GameObject conteinerAdmin;
    public Transform content2;
    public Sprite krest;
    public Sprite gal;
   // private List<int> activeFlag = new List<int>();
    private List<GameObject> UserData = new List<GameObject>();
    
    public void OnEnable()
    {
        int ty = 0;
        ty = AccessPoint.chekingNull();

        for (int i = 1; i <= ty; i++)
        {
            string[] str5 = new string[5];
            str5 = AccessPoint.UserSearch2(i);

            GameObject nConteiner = Instantiate(conteiner, transform.position, Quaternion.identity);
            GameObject recod1 = nConteiner.transform.Find("tlogin").gameObject;
            recod1.GetComponent<Text>().text = str5[0]+' '+str5[1];
            GameObject recod2 = nConteiner.transform.Find("tgrupa").gameObject;
            recod2.GetComponent<Text>().text = str5[2]; 
            GameObject recod3 = nConteiner.transform.Find("tlevel").gameObject;
            recod3.GetComponent<Text>().text = str5[3];
            GameObject recod4 = nConteiner.transform.Find("tdata").gameObject;
            recod4.GetComponent<Text>().text = str5[4];

            nConteiner.transform.SetParent(content2);
            UserData.Add(nConteiner);
        }
    }

    public void OnDisable()
    {
        if (content2.childCount > 0)
        {
            //Debug.Log("2G(content2.childCount > 0)");
            List<GameObject> usersChild = new List<GameObject>();
            for (int i = 0; i < content2.childCount; i++)
            {
                usersChild.Add(content2.GetChild(i).gameObject);
            }
            foreach (var t in usersChild)
            {
                { Destroy(t); }
            }

        }

    }

}
