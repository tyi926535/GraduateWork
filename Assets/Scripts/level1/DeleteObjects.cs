using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DeleteObjects : MonoBehaviour, IPointerClickHandler
{
    public GameObject scheme;
    public Texture2D cursorKrest;
    public GameObject Content;
    public void clickDelete()
    {
        scheme.SetActive(true);
        Cursor.SetCursor(cursorKrest, Vector2.zero, CursorMode.Auto);
        schemeChild(GameObject.FindGameObjectsWithTag("lineGroup"));
        schemeChild(GameObject.FindGameObjectsWithTag("queueGroup"));
        schemeChild(GameObject.FindGameObjectsWithTag("connectionGroup"));
        schemeChild(GameObject.FindGameObjectsWithTag("serverGroup"));
        schemeChild(GameObject.FindGameObjectsWithTag("entranceGroup"));
        var flag = scheme.transform.Find("flag");
        flag.gameObject.SetActive(true);
    }

    private string NumberStar(string nameDevice, int num)
    {
        string newName = "";
        var anArray = nameDevice.Split('*');
        if (anArray.Length > 1)
        {
            foreach (var a in anArray)
            {
                int x;
                if (int.TryParse(a, out x) == true)
                {
                    if (x != num) { newName += "*"+a; }
                }
                else
                {
                    newName += a;
                }
            }
        }
        return newName;
    }
    private string NumberStar2(string nameDevice, int num1,int num2)
    {
        string newName = "";
        var anArray = nameDevice.Split('*');
        if (anArray.Length > 1)
        {
            foreach (var a in anArray)
            {
                int x;
                if (int.TryParse(a, out x) == true)
                {
                    if (x != num1) { newName += "*" + a; }
                    else { newName += "*" + num2; }
                }
                else
                {
                    newName += a;
                }
            }
        }
        return newName;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        var objFlag = scheme.transform.Find("flag").gameObject;
        if ((objFlag.activeSelf == true)&&(eventData.pointerId == -1)&&(transform.tag != "Untagged"))
        {
            var nameDevice = transform.name;
            var anArray = nameDevice.Split('*');
            if (anArray.Length > 1)
            {
                foreach (var a in anArray)
                {
                    int connection;
                    if (int.TryParse(a, out connection) == true)
                    {
                        var allDatabaseChangeableParameters3 = Resources.LoadAll<Communications>("connection");
                        var selectedOption3 = allDatabaseChangeableParameters3[connection];
                        GameObject queue = selectedOption3.queue;
                        GameObject device = selectedOption3.device;
                        GameObject line = selectedOption3.line;
                        queue.name = NumberStar(queue.name, connection);
                        device.name = NumberStar(device.name, connection);
                        line.name = NumberStar(line.name, connection);
                        int flag = 1;
                        if (transform.tag == "queueGroup") { flag = 1; }
                        else
                        {
                            if (transform.tag == "lineGroup") { flag = 3; }
                            else { flag = 2; }
                        }
                        if ((flag == 1)||(flag==3))
                        {
                            Transform[] elements = device.GetComponentsInChildren<Transform>(true);
                            foreach (Transform element in elements)
                            {
                                if (element.name == "number")
                                {
                                    element.GetComponent<Text>().text = (Convert.ToInt32(element.GetComponent<Text>().text)+1).ToString();
                                }
                            }
                        }
                        if ((flag == 2) || (flag == 3))
                        {
                            if (transform.tag == "connectionGroup")
                            {
                                Transform[] elements = queue.GetComponentsInChildren<Transform>(true);
                                foreach (Transform element in elements)
                                {
                                    if (element.name == "ImageBlue")
                                    {
                                        var numElement = element.Find("number");
                                        numElement.GetComponent<Text>().text = (Convert.ToInt32(numElement.GetComponent<Text>().text) + 1).ToString();
                                    }
                                }
                            }
                            if (transform.tag == "serverGroup")
                            {
                                Transform[] elements = queue.GetComponentsInChildren<Transform>(true);
                                foreach (Transform element in elements)
                                {
                                    if (element.name == "ImageGreen")
                                    {

                                        var numElement = element.Find("number");
                                        numElement.GetComponent<Text>().text = (Convert.ToInt32(numElement.GetComponent<Text>().text) + 1).ToString();
                                    }
                                }
                            }
                            if (transform.tag == "entranceGroup")
                            {
                                Transform[] elements = queue.GetComponentsInChildren<Transform>(true);
                                foreach (Transform element in elements)
                                {
                                    if (element.name == "ImageBlack")
                                    {

                                        var numElement = element.Find("number");
                                        numElement.GetComponent<Text>().text = (Convert.ToInt32(numElement.GetComponent<Text>().text) + 1).ToString();
                                    }
                                }
                            }
                        }
                        Destroy(line);
                        int counter = PlayerPrefs.GetInt("counter");
                        if (counter > 0)
                        {
                            var selectedOption31 = allDatabaseChangeableParameters3[counter];
                            selectedOption3.queue = selectedOption31.queue;
                            selectedOption3.line = selectedOption31.line;
                            selectedOption3.device = selectedOption31.device;
                            selectedOption3.line.name=NumberStar2(selectedOption3.line.name, counter, connection);
                            selectedOption3.device.name=NumberStar2(selectedOption3.device.name, counter, connection);
                            selectedOption3.queue.name = NumberStar2(selectedOption3.queue.name, counter, connection);
                            selectedOption31.queue = null;
                            selectedOption31.line = null;
                            selectedOption31.device = null;
                        }
                        else
                        {
                            selectedOption3.queue = null;
                            selectedOption3.device = null;
                        }
                        PlayerPrefs.SetInt("counter", counter - 1);
                    }
                }
            }
            var glaveName = nameDevice.Split('|');
            var contentElement = Content.transform.Find(glaveName[0]);
            contentElement.gameObject.SetActive(true);
            var elementnum = contentElement.GetComponentsInChildren<Transform>(true);
            foreach (Transform element in elementnum)
            {
                if (element.name == "number")
                {
                    element.GetComponent<Text>().text = (Convert.ToInt32(element.GetComponent<Text>().text) + 1).ToString();
                }
            }
            Destroy(gameObject);

        }
    }
    private void schemeChild(GameObject[] findTag)
    {
        foreach (var child in findTag)
        {
            child.transform.SetParent(scheme.transform);
        }
    }

}
