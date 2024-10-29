using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Testing4L : MonoBehaviour
{
    public GameObject content;
    public GameObject Error;
    public GameObject pl21;
    public GameObject pl22;
    public GameObject pl23;
    public GameObject pl24;
    public GameObject Testing4;
    public GameObject Constructor4;

    public void Examination()
    {
     int debag = 0;
        Transform[] elements = content.GetComponentsInChildren<Transform>(false);
        if (elements != null)
        {
            foreach (Transform element in elements)
            {
                if ((element.name != "Text") && (element.name != "num") && (element.name != "Content")) { debag++; Debug.Log(element.name); }
            }
        }
        if (debag > 0) { Error.SetActive(true); Debug.Log(debag); }
        else
        {
            NumberPl(pl21, 0);
            NumberPl(pl22, 1);
            NumberPl(pl23, 2);
            NumberPl(pl24, 3);
            Testing4.SetActive(true);
            Constructor4.SetActive(false);
        }
    }
    private void NumberPl(GameObject p2,int num)
    {
        var ContinuedBlog1 = p2.transform.parent.parent.parent;
        var procent1 = ContinuedBlog1.Find("procent2");
        if (procent1 != null)
        {
            var textPr = procent1.Find("Text (Legacy)");
            if (textPr != null)
            {
                int intPr=Convert.ToInt32(textPr.GetComponent<Text>().text);
                var allDCP = Resources.LoadAll<PercentageRatio>("level3");
                var sOpt = allDCP[num];
                var p2Text = p2.transform.Find("Text (Legacy)");
                Debug.Log("flag1");
                if (p2Text != null)
                {
                    int intp2 = Convert.ToInt32(p2Text.GetComponent<Text>().text);
                    sOpt.numberPeople = (intp2*intPr/100);
                }
            }
        }
    }
}
