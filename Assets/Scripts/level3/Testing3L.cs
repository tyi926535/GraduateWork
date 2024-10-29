using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Testing3L : MonoBehaviour
{
    [SerializeField] public GameObject Right4th;
    [SerializeField] public GameObject Left4th;
    public GameObject Error;
    public GameObject Path2;
    public GameObject[] pl1= new GameObject[2];
    public GameObject[] pl2= new GameObject[4];
    public GameObject[] pl3= new GameObject[8];
    public GameObject Testing3;
    public GameObject Constructor3;


    
    public void Examination()
    {
        int debag = 0;
        if (Right4th.activeSelf == false ) { debag += 1; }
        if (Left4th.activeSelf == false) { debag += 1;  }
        Transform[] elements = Path2.GetComponentsInChildren<Transform>(false);
        int vipProcent = 0;
        foreach (Transform element in elements)
        {
            if ((element.tag == "percent") )
            {
                var procent=element.gameObject.GetComponent<InputField>().text;
                if(procent == "") { debag += 1; }
            }
            if ((element.tag == "percentVip"))
            {
                var procent = element.gameObject.GetComponent<InputField>().text;
                if (procent == "") { debag += 1; }
                vipProcent++;

            }
        }
        if (vipProcent != 2) { debag += 1; }
        if (debag > 0) { Error.SetActive(true); }
        else
        {
            //int namin = 0, paren1 = 0, paren2=0,num = 5;
            
            NumberPl1(0, 0, 0, 4);
            NumberPl1(1, 0, 0, 5);
            NumberPl1(2, 0, 1, 6);
            NumberPl1(3, 0, 1, 7);
            NumberPl1(4, 1, 2, 8);
            NumberPl1(5, 1, 2, 9);
            NumberPl1(6, 1, 3, 10);
            NumberPl1(7, 1, 3, 11);
            Testing3.SetActive(true);
            Constructor3.SetActive(false);
            
        }
    }

    private void NumberPl1(int namin, int paren1, int paren2, int num)
    {
        var parentG = pl3[namin].transform.parent.parent.gameObject;
        if (parentG.activeSelf != false)
        {
            var pl1Text = pl1[paren1].transform.Find("Text (Legacy)");
            if (pl1Text != null)
            {
                int pl1Int = Convert.ToInt32(pl1Text.GetComponent<Text>().text);
                var pl2Text = pl2[paren2].transform.Find("Text (Legacy)");
                if (pl2Text != null)
                {
                    int pl2Int = Convert.ToInt32(pl2Text.GetComponent<Text>().text);
                    var pl3Text = pl3[namin].transform.Find("Text (Legacy)");
                    if (pl3Text != null)
                    {
                        int pl3Int = Convert.ToInt32(pl3Text.GetComponent<Text>().text);
                        var allDCP = Resources.LoadAll<PercentageRatio>("level3");
                        var sOpt = allDCP[num];
                        sOpt.numberPeople = (pl1Int * pl2Int * pl3Int / 10000);
                    }
                }
            }
        }
        else
        {
            parentG = pl2[paren2].transform.parent.parent.gameObject;
            if (parentG.activeSelf != false)
            {
                var pl1Text = pl1[paren1].transform.Find("Text (Legacy)");
                if (pl1Text != null)
                {
                    int pl1Int = Convert.ToInt32(pl1Text.GetComponent<Text>().text);
                    var pl2Text = pl2[paren2].transform.Find("Text (Legacy)");
                    if (pl2Text != null)
                    {
                        int pl2Int = Convert.ToInt32(pl2Text.GetComponent<Text>().text);
                        var allDCP = Resources.LoadAll<PercentageRatio>("level3");
                        var sOpt = allDCP[paren2];
                        sOpt.numberPeople = (pl1Int * pl2Int  / 100);
                    }
                }
            }
        }
    }

}
