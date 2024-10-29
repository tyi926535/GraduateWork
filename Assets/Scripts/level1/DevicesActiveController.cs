using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DevicesActiveController : UILineRenderer, IDragHandler, IPointerClickHandler, IPointerUpHandler
{
    public GameObject scheme;
    
    public void OnDrag(PointerEventData eventData)
    {
        if (scheme.activeSelf == false)
        {
            transform.position = eventData.pointerCurrentRaycast.screenPosition;
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if ((eventData.pointerId == -2)&&(scheme.activeSelf==false))
        {
            var devicesActive = eventData.pointerPress;
           var listScroll= devicesActive.transform.Find("ScrollView");
           listScroll.GameObject().SetActive(true);
            //var posisionScroll=listScroll.GetComponent<RectTransform>().transform;
            var pointer—oordinates = eventData.position;
            Vector3 mouse = new Vector3(pointer—oordinates.x+ 83, pointer—oordinates.y - 110, 0);
            listScroll.GetComponent<RectTransform>().position =mouse;
            
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (scheme.activeSelf == false)
        { 
            var nameDevice = transform.name;
            var anArray = nameDevice.Split('*');
            if (anArray.Length > 1)
            {
                foreach (var a in anArray)
                {
                    int connection;
                    if (int.TryParse(a, out connection) ==true)
                    {
                        var allDatabaseChangeableParameters3 = Resources.LoadAll<Communications>("connection");
                        var selectedOption3 = allDatabaseChangeableParameters3[connection];
                        GameObject line = selectedOption3.line;
                        GameObject device = selectedOption3.device;
                        GameObject queue= selectedOption3.queue;    

                        var point1 = new Vector3(queue.transform.position.x, queue.transform.position.y, 0);
                        var point2 = new Vector3(device.transform.position.x, device.transform.position.y, 0);
                        LineImage(line, point1, point2);
                    }
                }
            }
        }
    }
}
