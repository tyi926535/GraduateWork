using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameO : MonoBehaviour
{
    // Start is called before the first frame update
    public Image green;
    public GameObject update;
    public void Flower()
    {
        if (update != null)
        {
             
            if(green.color== Color.white) 
            { 
                green.color = new Color(122, 255, 0, 170);
            }
            else green.color =Color.white;
        }
        
       
    }
}
