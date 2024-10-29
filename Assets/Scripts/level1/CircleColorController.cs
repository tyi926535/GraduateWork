using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Xml.Linq;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
//using ListDevices;

public class CircleColorController : UILineRenderer, IPointerClickHandler
{
    public GameObject line;
    public GameObject scheme;
    public GameObject Panel;

    public void OnPointerEnter()
    {
        this.transform.localScale = new Vector3(2f, 2f,0);
    }

    public void OnPointerExit()
    {
        this.transform.localScale = new Vector3(1f, 1f, 0);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject queue=null;
        GameObject device=null;
        var colorCircle = eventData.pointerPress;//colorCircle
        var groupActive = colorCircle.transform.parent.parent.gameObject;//Group
        groupActive.transform.SetParent(scheme.transform.parent);
        Transform[] children = groupActive.GetComponentsInChildren<Transform>(false);
        foreach (var child in children)
        {
            if (child.name == colorCircle.name) { child.gameObject.SetActive(false); }
        }
        Transform[] elements = scheme.GetComponentsInChildren<Transform>(true);
        foreach (Transform element in elements)
        {
            if ((element.tag != "Untagged")&&(element.tag != "circle"))
            {
                element.SetParent(Panel.transform.Find(element.tag)); 
                if (element.tag== "queueGroup") { queue = element.gameObject; device = colorCircle.transform.parent.gameObject; } 
                else { device = element.gameObject; queue= colorCircle.transform.parent.gameObject; }
            }
            //Система: в название очереди записывается (название|номер_устройства*номер_линии,номер_линии,номер_линии) ,
            //в название линии записывает (номер_очереди&номер_устройства|номер_линии) в тег довавляется (тег_устройства),
            //в названии устройства записывается (название|номер_устройства*номер_линии)

        }
        scheme.SetActive(false);
        var lineGroup = Panel.transform.Find("lineGroup");
        GameObject newLine = Instantiate(line, new Vector3(lineGroup.transform.position.x, lineGroup.transform.position.y, 0), Quaternion.identity);
        newLine.transform.SetParent(lineGroup);
        var numLine = lineGroup.childCount;
        newLine.name = "line"+"|"+ numLine;
        newLine.tag = "lineGroup";
        //PlayerPrefs.SetString(device.name, newLine.name);

        int counter=PlayerPrefs.GetInt("counter")+1;
        PlayerPrefs.SetInt("counter", counter);
        var allDatabaseChangeableParameters3 = Resources.LoadAll<Communications>("connection");
        var selectedOption3 = allDatabaseChangeableParameters3[counter];
        selectedOption3.line = newLine;
        selectedOption3.queue = queue;
        selectedOption3.device = device;
        queue.name = queue.name + "*" + counter;
        device.name = device.name + "*" + counter;
        newLine.name = line.name + "*" + counter;


        


        var point1 = new Vector3(queue.transform.position.x, queue.transform.position.y,0);
        var point2 = new Vector3(device.transform.position.x, device.transform.position.y,0);
        Color color= colorCircle.GetComponent<Image>().color;
        LineImage(newLine, point1, point2);
        newLine.GetComponent<Image>().color = color;
        Transform[] elements2 =device.GetComponentsInChildren<Transform>(true);
        int num = 0;
        Transform imageOrange=null;
        foreach (var element in elements2)
        {
            if(element.name== "number") 
            { 
                string numString=element.GetComponent<Text>().text;
                num=Convert.ToInt32(numString)-1;
                element.GetComponent<Text>().text = num.ToString();
                //if (num <= 0) { activeElement.SetActive(false); }
            }
            if(element.name== "ImageOrange")
            {
                imageOrange = element;
            }
        }
        if (num <= 0) { imageOrange.gameObject.SetActive(false); }
        string imageColor = "";
        if (device.tag == "connectionGroup") { imageColor = "ImageBlue"; }
        if (device.tag == "entranceGroup") { imageColor = "ImageBlack"; }
        if (device.tag == "serverGroup") { imageColor = "ImageGreen"; }
        Transform imageCircle = null;
        Transform[] elements3 = queue.GetComponentsInChildren<Transform>(true);
        foreach (var element in elements3)
        {
            if (element.name == imageColor)
            {
                imageCircle= element;
            }
        }
        Transform[] elements4 = imageCircle.GetComponentsInChildren<Transform>(true);
            foreach (var element in elements4)
            {
                if (element.name == "number")
                {
                    string numString = element.GetComponent<Text>().text;
                    var num2 = Convert.ToInt32(numString) - 1;
                    element.GetComponent<Text>().text = num2.ToString();
                    if (num2 <= 0) { imageCircle.gameObject.SetActive(false); }
                }
            }
    }
}
