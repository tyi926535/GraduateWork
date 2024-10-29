using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ListPeople : MonoBehaviour
{
    public Transform[] points;
    public Sprite[] spritePeople = new Sprite[2];
    //public float speed = 0;
    public Text quantity;
    public Text plus;
    public int secMax;
    public int sec;
    [SerializeField] private int delta;
    public GameObject TextObject;
    public Text enterPeople;

    private int flag = 0;
    public GameObject people;
    public Transform peopleParent;
    public Text periodT;
    public Text numT;
    public Text treatmentT;

    private List<GameObject> listP = new List<GameObject>();
    void Start()
    {
        treatmentT.text = periodT.text;
        foreach (var p in points)
        {
            p.GetComponent<Image>().color = Color.green;
        }
        StartCoroutine(PatienceScale());

    }


    IEnumerator AddPeople()
    //void AddPeople()
    {
        if (sec % Convert.ToInt32(numT.text) == 0)
        {
            people.SetActive(true);
            GameObject newGO = Instantiate(people, new Vector3(0, 0, 0), Quaternion.identity);
            newGO.transform.SetParent(peopleParent);
            newGO.transform.localScale = new Vector3(1, 1, 1);
            newGO.transform.position = points[1].position;
            int num = Convert.ToInt32(quantity.GetComponent<Text>().text) + 1;
            quantity.text = num.ToString();
            people.SetActive(false);

            num = Convert.ToInt32(enterPeople.GetComponent<Text>().text) + 1;
            enterPeople.text = num.ToString();
            listP.Add(newGO);
        }
        yield return null;
    }
    IEnumerator ListPeople1()
    //void ListPeople1()
    {
        if (listP.Count != 0)
        {
            GameObject predP = listP[0];
            for (int i = 0; i < listP.Count; i++)
            {
                if (i > 9) { break; }
                if ((predP == listP[i]))
                {
                    if (listP[i].transform.position != points[9].position)
                    {
                        listP[i].transform.GetComponent<Image>().sprite = spritePeople[1];
                        int num2 = Convert.ToInt32(quantity.text) - 1;
                        if (num2 < 0) { num2 = 0; }
                        quantity.text = num2.ToString();
                        flag = -1;
                        points[9].GetComponent<Image>().color = Color.red;
                        listP[i].transform.position = points[9].position;
                    }
                    if (flag == 1)
                    {
                        var plusT = plus.text;
                        var plusInt = Convert.ToInt32(plusT) + 1;
                        plus.text = plusInt.ToString();
                        points[9].GetComponent<Image>().color = Color.green;
                        Destroy(listP[i]);
                        listP.RemoveAt(i);
                        i--;
                    }
                }
                else
                {
                    for (int j = 1; j < 9; j++)
                    {
                        if (predP.transform.position == points[j + 1].position)
                        {
                            listP[i].transform.position = points[j].position;
                            points[j].GetComponent<Image>().color = Color.red;
                        }
                    }
                }
                if (i > 0)
                {
                    if (listP[i].transform.GetComponent<Image>().color == Color.black)
                    {
                        Destroy(listP[i]);
                        listP.RemoveAt(i);
                        i--;
                        var minus = TextObject.transform.Find("minus");
                        if (minus != null)
                        {
                            int num2 = Convert.ToInt32(quantity.text) - 1;
                            if (num2 < 0) { num2 = 0; }
                            quantity.text = num2.ToString();

                            var minusT = minus.GetComponent<Text>().text;
                            var minusInt = Convert.ToInt32(minusT) + 1;
                            minus.GetComponent<Text>().text = minusInt.ToString();
                            Debug.Log("minus+1");
                        }
                    }
                    else
                    {
                        predP = listP[i];
                    }
                }
            }
        }
        yield return null;
    }

    IEnumerator PatienceScale()
    {
        while (true)
        {
           // Debug.Log("treatment=" + treatment);
            sec += delta;
            if (sec < secMax + 1)
            {
                StartCoroutine(AddPeople());
                if (flag == -1)
                {
                    treatmentT.text = (Convert.ToInt32(treatmentT.text)-delta).ToString();
                    if (Convert.ToInt32(treatmentT.text) == 0)
                    {
                        flag = 1;
                        treatmentT.text = periodT.text;
                        // Debug.Log("treatment="+ treatment);
                    }
                }
                StartCoroutine(ListPeople1());
            }
            yield return new WaitForSeconds(1);
        }
        
    }
}
