using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTask16 : MonoBehaviour
{
    public GameObject task16;

    public void OpenWindowsWithTask()
    {
        Debug.Log("+");
        if (transform.Find("Text").gameObject.activeSelf == true)
        {
            Debug.Log("++");
            task16.SetActive(true);
            task16.transform.parent.parent.gameObject.SetActive(true);
        }
    }
}
