using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class listScrollControllers : MonoBehaviour, IPointerClickHandler
{
    //public LineRenderer lineprovision;
    // public GameObject deviceBody;
    public GameObject circleColor;
    public GameObject container;
    public GameObject scheme;
    public GameObject activeElement;
   // private bool flag = false;

    public void OnPointerClick(PointerEventData eventData)
    {
        var compoundActive = eventData.pointerPress;//ScrollView
        var deviceActive=compoundActive.transform.parent.gameObject;//DeviceActive1
        var posisionDevice1st= deviceActive.GetComponent<RectTransform>().transform;
        circleColor.SetActive(true);
        

        Transform[] children = container.GetComponentsInChildren<Transform>(true);
        foreach (var child in children)
        {
            if (child.name == circleColor.name) {child.gameObject.SetActive(true); }
        }
        scheme.SetActive(true);
        ////
        foreach (var child in GameObject.FindGameObjectsWithTag(container.name))
        {
            child.transform.SetParent(scheme.transform);
        }
        /////
        //container.transform.SetParent(scheme.transform);
       
        deviceActive.transform.SetParent(scheme.transform);
        

}



}
