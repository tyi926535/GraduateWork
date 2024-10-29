using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartTesting2 : MonoBehaviour
{
    public GameObject line1;
    public GameObject line2;
    public GameObject connection;
    // Start is called before the first frame update
    void Start()
    {
        int serverGroup = 0;
        int queueGroup = 0;
        int connectionGroup = 0;
        int entranceGroup = 0;
        int number = 0;
        var allCommunications = Resources.LoadAll<Communications>("connection");
        for (int i = 0; i < 12; i++)
        {
            var selectedO2 = allCommunications[i];
            if (selectedO2.queue != null) { queueGroup++; }
            if (selectedO2.device != null)
            {
                if (selectedO2.device.tag == "serverGroup") { serverGroup++; }
                if (selectedO2.device.tag == "connectionGroup") { connectionGroup++; }
                if (selectedO2.device.tag == "entranceGroup") { entranceGroup++; }
            }

        }
        
            number = 2;
       
        if ((serverGroup / 2 == 1) && (queueGroup / 2 == 1) && (entranceGroup / 2 == 1))
        {
            line1.SetActive(true);
            line2.SetActive(true);
        }
        if ((serverGroup / 1 == 1) && (queueGroup / 1 == 1) && (entranceGroup / 1 == 1))
        {
            line1.SetActive(true);
            line2.SetActive(false);
        }
        if (connectionGroup!=0)
        {
            connection.SetActive(true);
        }



    }
}
