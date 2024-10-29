using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer3 : MonoBehaviour
{
    public int sec = 0;
    public int min = 1;
    [SerializeField] private Text timer;
    public GameObject TextObject;
    public GameObject NextB;
    public GameObject ExitB;
    [SerializeField] private int delta = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ITimer());
    }

    // Update is called once per frame
    IEnumerator ITimer()
    {
        while (true)
        {
            if ((min <= 0) && (sec == 0))
            {
                min = 0;
                sec = 1;
            }
            if (sec == 0)
            {
                min--;
                sec = 60;
            }
            sec -= delta;
            timer.text = min.ToString("D2") + ":" + sec.ToString("D2");

           
            if ((min == 0) && (sec == 1))
            {
                var minus = TextObject.transform.Find("minus");
                if (minus != null)
                {
                    var minusInt = Convert.ToInt32(minus.GetComponent<Text>().text);
                    if (minusInt > 0)
                    {
                        var falseT = TextObject.transform.Find("false");
                        if (falseT != null)
                        {
                            falseT.gameObject.SetActive(true);
                            ExitB.SetActive(true);
                        }
                    }
                    else
                    {
                        var trueT = TextObject.transform.Find("true");
                        if (trueT != null)
                        {
                            trueT.gameObject.SetActive(true);
                            NextB.SetActive(true);
                        }
                    }
                }
            }
            yield return new WaitForSeconds(1);
        }
    }
}
