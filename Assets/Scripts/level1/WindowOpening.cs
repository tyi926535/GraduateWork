using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class WindowOpening : MonoBehaviour, IPointerClickHandler
{

    public GameObject properties;
    public int flag;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.pointerId == flag)
        {
            properties.SetActive(true);
            var firstProperties = properties.transform.parent.gameObject;
            firstProperties.SetActive(true);
        }
    }
}
