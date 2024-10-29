using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CancelWindow : MonoBehaviour
{
    public GameObject ImageComp;
    public GameObject MiniPanel;
    public GameObject TrigerCansle;
    public void CansleFunction()
    {
        
        foreach (Transform child in MiniPanel.transform)
        {
            if ((child.name!=ImageComp.name)&&(child.name != TrigerCansle.name)) { child.gameObject.SetActive(false);  }
        }
        MiniPanel.gameObject.SetActive(false);
    }
}
