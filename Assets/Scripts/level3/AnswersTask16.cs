using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class AnswersTask16 : MonoBehaviour
{
    public InputField inputAnswers;
    public GameObject buttonAnswers;

    public void AddAnswers()
    {
        var procent = inputAnswers.placeholder.GetComponent<Text>().text;
        if (procent == inputAnswers.text)
        {
            Transform[] elements = buttonAnswers.GetComponentsInChildren<Transform>(false);
            if (elements != null)
            {
                foreach (Transform element in elements)
                {
                    var num = element.Find("num");
                    if (num != null)
                    {  num.gameObject.SetActive(true); }
                    var textPole= element.Find("Text");
                    if (textPole != null) { textPole.gameObject.SetActive(false); }
                }
            }
        }
    }
}
