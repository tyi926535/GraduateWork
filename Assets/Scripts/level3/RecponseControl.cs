using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class RecponseControl : MonoBehaviour
{
    public GameObject content;
    public GameObject task16;
    public void TwoClick()
    {
        var textButton = transform.Find("num");
        if (textButton.gameObject.activeSelf != false)
        {
            Transform[] elements = content.GetComponentsInChildren<Transform>(false);
            foreach (Transform element in elements)
            {
                if ((element.tag == "butT"))
                {
                    element.tag = "Untagged";
                    element.GetComponent<Image>().color = Color.white;
                }
            }
            transform.tag = "butT";
            transform.GetComponent<Image>().color = Color.yellow;
        }
        else
        {
            OpenWindowsWithTask();
        }

        
    }
    public void OpenWindowsWithTask()
    {
        
            //Debug.Log("++");
            task16.SetActive(true);
            task16.transform.parent.parent.gameObject.SetActive(true);
    }
    public void AddRecponse()
    {
        var textButton = transform.Find("Text (Legacy)").gameObject.GetComponent<Text>().text;
        if (textButton == "")
        {
            Transform[] elements = content.GetComponentsInChildren<Transform>(false);
            if (elements != null)
            {
                foreach (Transform element in elements)
                {
                    if ((element.tag == "butT"))
                    {
                        var num = element.Find("num").GetComponent<Text>().text;
                        int number = 100 - Convert.ToInt32(num);
                        var parentPercent = transform.parent;
                        string nameParallelParent = "";
                        if (parentPercent.name == "ContinuedBlog2") { nameParallelParent = "ContinuedBlog1"; }
                        if (parentPercent.name == "ContinuedBlog1") { nameParallelParent = "ContinuedBlog2"; }
                        var ParallelParent = parentPercent.parent.Find(nameParallelParent);
                        if (ParallelParent != null)
                        {
                            var procent = ParallelParent.Find("procent2");
                            if (procent != null)
                            {
                                var parallelProc = procent.transform.Find("Text (Legacy)").gameObject.GetComponent<Text>().text;
                                if ((parallelProc == number.ToString())||(parallelProc==""))
                                {
                                    transform.Find("Text (Legacy)").gameObject.GetComponent<Text>().text = num;
                                    element.tag = "Untagged";
                                    element.GetComponent<Image>().color = Color.white;
                                    element.gameObject.SetActive(false);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    
}
