using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PeopleMovement : MonoBehaviour
{

    private int sec = 0;
    public float[] secTime;

    public GameObject true1;
    public GameObject false1;
    [SerializeField] private int delta = 1;
    public GameObject TextObject;


    void Start()
    {
        StartCoroutine(PatienceScale());
    }

    IEnumerator PatienceScale()
    {
        while (true)
        {
            sec += delta;
            if ((true1.activeSelf == false)&& (false1.activeSelf == false))
            {
               if (sec == secTime[0])
                {
                    transform.GetComponent<Image>().color = Color.yellow;
                }
                if (sec == secTime[1])
                {
                    transform.GetComponent<Image>().color = Color.red;
                }
                if (sec == secTime[2])
                {
                    transform.GetComponent<Image>().color = Color.black;
                }
            }


            yield return new WaitForSeconds(1);
        }
    }
}
