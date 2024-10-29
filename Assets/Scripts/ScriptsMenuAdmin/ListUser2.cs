using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ListUser2 : MonoBehaviour
{
    public GameObject conteiner;
    public GameObject conteiner1;
    public GameObject conteinerAdmin;
    public Button btn1;
    public Transform content2;
    public Sprite krest;
    public Sprite gal;
    //private List<GameObject> UserData = new List<GameObject>();


    public void ExLU()
    {
        if (content2.childCount > 0)
        {
            List<GameObject> usersChild = new List<GameObject>();
            RewriteText();
        }
    }
    public void RewriteText()//Переписывание файла
    {
        List<GameObject> UserData = new List<GameObject>();

        for (int i = 0; i < content2.childCount; i++)
        {
            UserData.Add(content2.GetChild(i).gameObject);
        }
        int ty = 0;
        ty = AccessPoint.chekingNull();
        int k = 1;
        foreach (var i in UserData)
        {
            string[] str3 = new string[3];
            GameObject recod1 = i.transform.Find("tlogin").gameObject;
            string fio = recod1.GetComponent<Text>().text;
            string[] FIO = fio.Split(new char[] { ' ' });
            str3[0] = FIO[0];
            str3[1] = FIO[1];
            GameObject recod3 = i.transform.Find("tgrupa").gameObject;
            str3[2] = recod3.GetComponent<Text>().text;
            GameObject recod4 = i.transform.Find("tactive").gameObject;
            if (recod4.GetComponent<Image>().sprite== krest)
            {
                AccessPoint.AUbd2(str3);
            }
            else
            {

                AccessPoint.UpdateId(k, str3);
                k++;

            }

        }
            btn1.GetComponent<Button>().onClick.Invoke();
    }
       

    
    
}
