using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScheme : MonoBehaviour
{
    public GameObject scheme;
    public GameObject Panel;
   public void clickKrest()
    {
        Transform[] elements = scheme.GetComponentsInChildren<Transform>(true);
        foreach (Transform element in elements)
        {
            if ((element.tag != "Untagged")&& (element.tag != "circle"))
            {
                element.SetParent(Panel.transform.Find(element.tag));
            }
            if ( (element.tag == "circle"))
            {
                element.gameObject.SetActive(false);
            }
        }
        scheme.SetActive(false);
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        var flag = scheme.transform.Find("flag");
        flag.gameObject.SetActive(false);

    }
}
