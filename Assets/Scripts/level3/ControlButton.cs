using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlButton : MonoBehaviour
{
    public GameObject PartD;
    public void ClickButtonMP()
    {
        var pmTransform = this.transform.Find("pm");
        if (pmTransform != null)
        {
            var pmText = pmTransform.GetComponent<Text>().text;
            if (pmText == "-") 
            {
                pmTransform.GetComponent<Text>().text = "+"; 
                PartD.SetActive(false);
            }
            else { pmTransform.GetComponent<Text>().text = "-"; PartD.SetActive(true); }
        }
    }
}
