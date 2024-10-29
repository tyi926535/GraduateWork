using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PercentagesBlocks : MonoBehaviour
{
    public GameObject field;
    public Text textField;
    public void InterestCounter()
    {
        var getText = textField.text;
        if (getText != null)
        {
            int number = 0;
            //field.GetComponent<InputField>().placeholder.GetComponent<Text>().text = getText;
            if (int.TryParse(textField.text, out var x)) {
                if (x > 100) { x = 100; }
                if (x < 0) {  x = 0; }
                field.gameObject.GetComponent<InputField>().text=x.ToString();
                number = 100 - x;
                var parentPercent=field.transform.parent;
                string nameParallelParent = "";
                if(parentPercent.name== "ContinuedBlog2") { nameParallelParent = "ContinuedBlog1"; }
                if (parentPercent.name== "ContinuedBlog1") { nameParallelParent = "ContinuedBlog2"; }
                var ParallelParent = parentPercent.parent.Find(nameParallelParent);
                if (ParallelParent != null)
                {
                    var procent = ParallelParent.Find("procent");
                    if (procent != null)
                    {
                        procent.gameObject.GetComponent<InputField>().text=number.ToString();
                    }
                }
            }
        }
    }
    
}
