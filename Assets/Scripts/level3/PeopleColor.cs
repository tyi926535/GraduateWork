using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class PeopleColor : MonoBehaviour
{
    public Sprite[] colorPeople= new Sprite[3]; 
    private int colorCount = -1;
    private int sec = 25;
    public GameObject Part34;
    public GameObject NextB;
    public GameObject ExitB;
    [SerializeField] private int delta = 0;

    private void Start()
    {
        StartCoroutine(ITimer());
    }
    IEnumerator ITimer()
    {
        while (sec>0)
        {
            sec -= delta;
            if ((sec % 5 == 0)&&(sec!=0)) { ColorChange(); }
            if (sec == 0)
            {
                
                Part34.SetActive(true);
                Transform[] elements = Part34.GetComponentsInChildren<Transform>(true);
                foreach (Transform element in elements)
                {
                    if (element.name == "plus")
                    {
                        if (element.gameObject.activeSelf == false)
                        { ExitB.SetActive(true); }
                        else
                        {
                            NextB.SetActive(true);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
    }

    public void ColorChange()
    {
        if (colorCount < 2)
        {
            colorCount++;
            transform.GetComponent<Image>().sprite = colorPeople[colorCount];
        }

    }
    
}
