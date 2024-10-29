using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using System;
using UnityEngine.UI;

public class StartTestPart3 : MonoBehaviour
{
    [SerializeField] public GameObject TestingPart3;
    [SerializeField] public GameObject TestingPart4;
    public GameObject[] platforms= new GameObject[12];
    public GameObject Part34;
    // Start is called before the first frame update
    void Start()
    {
        if(TestingPart3.activeSelf != false)
        {
            Debug.Log("Testing3 Go");
            var allDCP = Resources.LoadAll<PercentageRatio>("level3");
            RunMassive();
            int p31 = allDCP[4].numberPeople;
            int p35 = allDCP[8].numberPeople;
            if (p31+p35 ==52)
            {
                Transform[] elements = Part34.GetComponentsInChildren<Transform>(true);
                foreach (Transform element in elements)
                {
                    if(element.name== "plus") { element.gameObject.SetActive(true); }
                    if (element.name== "num") { element.GetComponent<Text>().text = Convert.ToString(p31 + p35); }
                    if(element.name== "minus") { element.gameObject.SetActive(false); }
                } 
            }
            else
            {
                Transform[] elements = Part34.GetComponentsInChildren<Transform>(true);
                foreach (Transform element in elements)
                {
                    if (element.name == "plus") { element.gameObject.SetActive(false); }
                    if (element.name == "num") { element.GetComponent<Text>().text = Convert.ToString(p31 + p35); }
                    if (element.name == "minus") { element.gameObject.SetActive(true); }
                }
            }
        }
        if (TestingPart4.activeSelf != false)
        {
            Debug.Log("Testing4 Go");
            var allDCP = Resources.LoadAll<PercentageRatio>("level3");
            RunMassive();
            int p31 = allDCP[1].numberPeople;
            int p35 = allDCP[3].numberPeople;
            if (p31 + p35 == 50)
            {
                Transform[] elements = Part34.GetComponentsInChildren<Transform>(true);
                foreach (Transform element in elements)
                {
                    if (element.name == "plus") { element.gameObject.SetActive(true); }
                    if (element.name == "num") { element.GetComponent<Text>().text = Convert.ToString(p31 + p35); }
                    if (element.name == "minus") { element.gameObject.SetActive(false); }
                }
            }
            else
            {
                Transform[] elements = Part34.GetComponentsInChildren<Transform>(true);
                foreach (Transform element in elements)
                {
                    if (element.name == "plus") { element.gameObject.SetActive(false); }
                    if (element.name == "num") { element.GetComponent<Text>().text = Convert.ToString(p31 + p35); }
                    if (element.name == "minus") { element.gameObject.SetActive(true); }
                }
            }

        }
    }

    private void RunMassive()
    {
        var allDCP = Resources.LoadAll<PercentageRatio>("level3");
        for (int i = 0; i < 12; i++)
        {
            var sOpt = allDCP[i];
            if (sOpt.numberPeople != 0)
            {
                var objPeople = platforms[i].transform.Find("people");
                if (objPeople != null)
                {
                    for (int j = 0; j < sOpt.numberPeople; j++)
                    {
                        var rand = new System.Random();
                        int xMin = sOpt._minX;
                        int xMax = sOpt._maxX;
                        int yMin = sOpt._minY;
                        int yMax = sOpt._maxY;
                        //int xSide = rand.Next(xMin, xMax);
                        //int ySide = rand.Next(yMin, yMax);
                        int xSide = rand.Next(-360, 360);
                        int ySide = rand.Next(-200, 200);
                        GameObject newGO = Instantiate(objPeople.gameObject, new Vector3(0, 0, 0), Quaternion.identity);
                        newGO.transform.SetParent(platforms[i].transform);
                        newGO.transform.localScale = new Vector3(1, 1, 1);
                        newGO.transform.localPosition = new Vector3(xSide, ySide, 0);
                        newGO.gameObject.SetActive(true);
                    }
                }
            }
        }
    }
}
