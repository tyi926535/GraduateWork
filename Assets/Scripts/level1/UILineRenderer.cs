using UnityEngine;
using System;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class UILineRenderer : MonoBehaviour
{

    public void LineImage(GameObject line, Vector3 point1, Vector3 point2)
    {
        float x1 = point1.x;
        float y1 = point1.y;
        float x2 = point2.x;
        float y2 = point2.y;
        float x3, y3;
        double lengthLine = Math.Sqrt((x1 - x2)*(x1-x2)+(y1-y2)*(y1-y2));
        float differenceY = Math.Abs(y1 - y2);
        //x3 = (Math.Abs(x1 - x2) / 2);
        //y3 = (Math.Abs(y1 - y2) / 2);
       // var Corner Math.Acos((b * b + c * c - a * a) / (2 * b * c)) * 180 / Math.PI);
       var Corner = Math.Acos(differenceY / lengthLine)*180/Math.PI; //”гол
        if ((y1 > y2) && (x1 > x2)) { Corner *= -1; }
        else { 
            if ((y2 > y1) && (x2 > x1)) { Corner *= -1; }
        }
        
        if (x1 > x2) { x3 = (x1 + x2) / 2; }
        else { x3= (x2 + x1) / 2;}
        if (y1 > y2) { y3= (y1 + y2) / 2;}
        else { y3= (y2 + y1) / 2;}
        line.GetComponent<RectTransform>().sizeDelta= new Vector2(7,(float)lengthLine);
        line.transform.position = new Vector3(x3, y3, point1.z);
        line.transform.rotation = Quaternion.Euler(new Vector3(0, 0, (float)Corner)); 
        
    }
}
