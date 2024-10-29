using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class StartCanvas : MonoBehaviour
{
    [SerializeField] private GameObject propertiesMenu;
    [SerializeField] private GameObject Content;
    [SerializeField] private Text entranceNumber;

    void Start()
    {
        //PlayerPrefs.DeleteAll();

        var allDatabaseChangeableParameters1 = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption1 = allDatabaseChangeableParameters1[0];
        selectedOption1.idUser = PlayerPrefs.GetInt("idUser");
        selectedOption1.levelWas = PlayerPrefs.GetInt("levelWas");
        PlayerPrefs.SetInt("counter",-1 );

        var allDatabaseChangeableParameters2 = Resources.LoadAll<DataBaseTime>("BDtime");
        var selectedOption2 = allDatabaseChangeableParameters2[0];
       //var selectedOption2= (DataBaseTime)ScriptableObject.CreateInstance(typeof(DataBaseTime));

        var flagInt=Convert.ToInt32(selectedOption2.levelWas+1);
        int value = 0;
        string level = "";
        if (flagInt == 1)
        {
            value = UnityEngine.Random.Range(0, 1);
            level = "level1";
        }
        if (flagInt == 2)
        {
            value = 0;
            level = "level2";
        }
        var allDatabaseChangeableParameters = Resources.LoadAll<DatabaseChangeableParameters>(level);
        var selectedOption = allDatabaseChangeableParameters[value];
        selectedOption.active1 = 1;
        foreach (Transform chapter in propertiesMenu.transform)
        {
            if (chapter.name == "connection")
            {
                var quantityConnection = chapter.Find("0pos");
                quantityConnection.GetComponent<Text>().text = selectedOption._connections.ToString();
            }
            if (chapter.name == "queue")
            {
                var quantityQueue = chapter.Find("0pos");
                quantityQueue.GetComponent<Text>().text = selectedOption._queue.ToString();
                var placesInLineQueue = chapter.Find("2pos");
                if (selectedOption._placesInLine == 0) { placesInLineQueue.GetComponent<Text>().text = "бесконечно"; }
                else { placesInLineQueue.GetComponent<Text>().text = selectedOption._placesInLine.ToString(); }
            }
            if (chapter.name == "server")
            {
                var quantityServer = chapter.Find("0pos");
                quantityServer.GetComponent<Text>().text = selectedOption._server.ToString();
                var requestProcessingServer = chapter.Find("1posOt-Do");
                if (selectedOption._maxrequestProcessing == 0) { requestProcessingServer.GetComponent<Text>().text = selectedOption._minrequestProcessing.ToString(); }
                else
                {
                    requestProcessingServer.GetComponent<Text>().text = selectedOption._minrequestProcessing.ToString() + "-" + selectedOption._maxrequestProcessing.ToString();
                }
            }
            if (chapter.name == "entrance")
            {
                var quantityEntrance = chapter.Find("0pos");
                quantityEntrance.GetComponent<Text>().text = selectedOption._entrances.ToString();
                var bandwidthEnt = chapter.Find("1pos");
                bandwidthEnt.GetComponent<Text>().text = selectedOption._bandwidth.ToString();
                var numberConnectionsQueueEnt = chapter.Find("2pos");
                numberConnectionsQueueEnt.GetComponent<Text>().text = selectedOption._numberConnectionsQueue.ToString();
            }

        }
        foreach (Transform chapter in Content.transform)
        {
            if (chapter.name == "connection")
            {
                var number= chapter.GetComponentsInChildren<Transform>();
                if (number != null)
                {
                    foreach (Transform t in number)
                    {
                        if (t.name == "number") { t.GetComponent<Text>().text = selectedOption._connections.ToString(); }
                    }
                }
            }
            if (chapter.name == "queue")
            {
                var number = chapter.GetComponentsInChildren<Transform>();
                if (number != null)
                {
                    foreach (Transform t in number)
                    {
                        if (t.name == "number") { t.GetComponent<Text>().text = selectedOption._queue.ToString(); }
                    }
                }
            }

            if (chapter.name == "server")
            {
                var number = chapter.GetComponentsInChildren<Transform>();
                if (number != null)
                {
                    foreach (Transform t in number)
                    {
                        if (t.name == "number") { t.GetComponent<Text>().text = selectedOption._server.ToString(); }
                    }
                }
            }

            if (chapter.name == "entrance")
            {
                var number = chapter.GetComponentsInChildren<Transform>();
                if (number != null)
                {
                    foreach (Transform t in number)
                    {
                        if (t.name == "number") { t.GetComponent<Text>().text = selectedOption._entrances.ToString(); }
                    }
                }
            }
            entranceNumber.text= selectedOption._numberConnectionsQueue.ToString();
        }
    }
}
