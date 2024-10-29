using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ListBreference : MonoBehaviour,
    IPointerDownHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    //int yr = 0;
    public GameObject opt;
    public GameObject brf;
    public Transform posit;

    public void OnPointerDown(PointerEventData eventData)
    {
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        opt.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        opt.SetActive(false);
    }
}
