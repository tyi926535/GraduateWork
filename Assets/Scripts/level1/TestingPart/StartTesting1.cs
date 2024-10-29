using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTesting1 : MonoBehaviour
{
    public GameObject line1;
    public GameObject line2;
    public GameObject line3;
    public Text period;
    public Text num;
    // Start is called before the first frame update
    void Start()
    {
        int serverGroup = 0;
        int queueGroup = 0;
        int connectionGroup = 0;
        int entranceGroup = 0;
        int number = 0;
        var allCommunications = Resources.LoadAll<Communications>("connection");
        
        for (int i=0;i<12;i++)
        {
            var selectedO2 = allCommunications[i];
            if (selectedO2.queue != null) { queueGroup++; }
            if(selectedO2.device != null) 
            {
                if(selectedO2.device.tag== "serverGroup") { serverGroup++; }
                if (selectedO2.device.tag == "connectionGroup") { connectionGroup++; }
                if (selectedO2.device.tag == "entranceGroup") { entranceGroup++; }
            }
        }
        
        var allDCP = Resources.LoadAll<DatabaseChangeableParameters>("level1");
        if (allDCP[0].active1 == 1)
        {
            number = 2;
        }
        if (allDCP[1].active1 == 1)
        {
            number = 3;
        }
        if ((serverGroup/3==1)&&(queueGroup/3==2)&&(entranceGroup/3==1)) 
        {
            
            line1.SetActive(true);
            line2.SetActive(true);
            line3.SetActive(true);
            if (number == 3)
            {
                num.text = 3.ToString();
                period.text = 6.ToString();
            }
        }
        if ((serverGroup/2 ==1 ) && (queueGroup / 2 == 2) && (entranceGroup / 2 == 1))
        {
           
            line1.SetActive(true);
            line2.SetActive(true);
            line3.SetActive(false);
            if (number == 3)
            {
                num.text = 1.ToString();
                period.text = 4.ToString();
            }
            if (number == 2)
            {
                num.text = 2.ToString();
                period.text = 4.ToString();
            }
        }
        if ((serverGroup / 1 == 1) && (queueGroup / 1 == 2) && (entranceGroup / 1 == 1))
        {
            
            line1.SetActive(true);
            line2.SetActive(false);
            line3.SetActive(false);
            if (number == 2)
            {
                num.text = 1.ToString();
                period.text = 4.ToString();
            }
            if (number == 2)
            {
                num.text = 2.ToString();
                period.text = 6.ToString();
            }
        }
        

    }
   
}
