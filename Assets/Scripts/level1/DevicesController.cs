using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DevicesController : MonoBehaviour, IPointerClickHandler
{
    public GameObject createDeviceBody;
    public Image originalDeviceImg;
    public Transform groupContainer;
    public string nameGO;
    [SerializeField] private GameObject Content;
    private float LastClickTime = 0.0f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == -1)
        {
            float timeFromLastClick = Time.time - LastClickTime;
            LastClickTime = Time.time;
            if (timeFromLastClick < 0.3)
            {

                var numberObject = groupContainer.transform.childCount + 1;

                ///Поправки для 2 уровня

                if (groupContainer.name== "serverGroup")
                {
                    var request = Content.transform.Find("requestProcessing");
                    if (request != null)
                    {
                        if (request == true)
                        {
                            var big = Convert.ToInt32(request.Find("timeBig").GetComponent<Text>().text);
                            var none = Convert.ToInt32(request.Find("timeNone").GetComponent<Text>().text);
                            var newAct = big - none * (numberObject - 1);
                            request.Find("timeAct").GetComponent<Text>().text = newAct.ToString();
                        }
                    }
                }
                //////


                GameObject newGO = Instantiate(createDeviceBody, new Vector3(groupContainer.transform.position.x, groupContainer.transform.position.y, 0), Quaternion.identity);
                newGO.transform.SetParent(groupContainer);
                newGO.tag = groupContainer.name;
                newGO.transform.localScale = new Vector3(1, 1, 1);
                newGO.transform.Find("DeviceImg").GetComponent<Image>().sprite = originalDeviceImg.sprite;
                newGO.name = nameGO+"|" + numberObject.ToString();
                var arrayNewGO= newGO.transform.GetComponentInChildren<Transform>();
                foreach (Transform t in arrayNewGO)
                {
                    if (t.tag == "circle") { t.gameObject.SetActive(false); }
                }
                GameObject variable = null;
                var number = transform.GetComponentsInChildren<Transform>();
                if (number != null)
                {
                    foreach (Transform t in number)
                    {
                        if (t.name == "number") { variable = t.gameObject; }
                    }
                    var num = variable.GetComponent<Text>();
                    num.text = (Convert.ToInt32(num.text) - 1).ToString();
                    if (Convert.ToInt32(num.text) == 0) { gameObject.SetActive(false); }
                }

                



            }
        }

    }
    

}
