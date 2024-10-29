using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ScrOpinion : MonoBehaviour,
    IPointerEnterHandler,
    IPointerExitHandler
{
    public GameObject opt;
    public void OnPointerEnter(PointerEventData eventData)
    {
        opt.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        opt.SetActive(false);
    }

}
