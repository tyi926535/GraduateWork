using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text textTimer;
    public GameObject HomePanel;
    private int sec = 0;
    public int min = 7;
    [SerializeField] private int delta = 0;
    private void Start()
    {
        StartCoroutine(ITimer());
    }
 
    IEnumerator ITimer()
    {
        while (true)
        {
            if ((sec == 1) && (min == 0)) { HomePanel.SetActive(true); }
            if ((sec == 0) && (min == 0)) { sec = 1; }
            if (sec == 0)
            {
                min--;
                sec = 60;
            }
            sec -= delta;
            textTimer.text=min.ToString("D2")+":"+sec.ToString("D2");
            yield return new WaitForSeconds(1);
        }
    }
}
