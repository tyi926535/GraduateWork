using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListPeople2 : MonoBehaviour
{
    public Transform[] points1;
    public Sprite[] spritePeople = new Sprite[1];

    //public float speed = 0;
    public Text plus;
    public int secMax;
    private int sec = 0;
    [SerializeField] private int delta = 2;
    public GameObject TextObject;
    public Text enterPeople;

    private int flag1 = 0;
    private int flag2 = 0;
    private float treatment;
    public float period;


    public GameObject people;
    public Transform peopleParent;
    public int num = 5;

    private List<GameObject> listP = new List<GameObject>();
    void Start()
    {
        treatment = period;
        foreach (var p in points1)
        {
            p.GetComponent<Image>().color = Color.green;
        }
        StartCoroutine(PatienceScale());
    }


    IEnumerator AddPeople()
    {
        //Debug.Log("AddPeople");
        if (sec % num == 0)
        {
            people.SetActive(true);
            GameObject newGO = Instantiate(people, new Vector3(0, 0, 0), Quaternion.identity);
            newGO.transform.SetParent(peopleParent);
            newGO.transform.localScale = new Vector3(1, 1, 1);
            newGO.transform.position = points1[0].position;
            people.SetActive(false);
            num = Convert.ToInt32(enterPeople.GetComponent<Text>().text) + 1;
            enterPeople.text = num.ToString();
            listP.Add(newGO);
        }
        yield return null;
    }
    IEnumerator ListPeople1()
    {
        if (listP.Count != 0)
        {
            GameObject predP = listP[0];
            for (int i = 0; i < listP.Count; i++)
            {
                if ((predP == listP[i]))
                {
                    if (listP[i].transform.position != points1[1].position)
                    {
                        listP[i].transform.GetComponent<Image>().sprite = spritePeople[0];
                        flag1 = -1;
                        points1[1].GetComponent<Image>().color = Color.red;
                        listP[i].transform.position = points1[1].position;
                    }
                    if (flag1 == 1)
                    {
                        var plusT = plus.text;
                        var plusInt = Convert.ToInt32(plusT) + 1;
                        plus.text = plusInt.ToString();
                        points1[1].GetComponent<Image>().color = Color.green;
                        Destroy(listP[i]);
                        listP.RemoveAt(i);
                        i--;
                    }
                }
                else{
                    if (listP[i].transform.position == points1[10].position)
                    {
                        if (flag1 == 1)
                        {
                            var plusT = plus.text;
                            var plusInt = Convert.ToInt32(plusT) + 1;
                            plus.text = plusInt.ToString();
                            points1[10].GetComponent<Image>().color = Color.green;
                            Destroy(listP[i]);
                            listP.RemoveAt(i);
                            i--;
                        }
                    }


                    
                     else
                    {
                        if (listP[i].transform.position == points1[0].position)
                        {

                            if (points1[9].GetComponent<Image>().color == Color.green)
                            {
                                listP[i].transform.position = points1[9].position;
                                // points1[18].GetComponent<Image>().color = Color.red;
                            }
                            else
                            {
                                if (points1[18].GetComponent<Image>().color == Color.green)
                                {
                                    listP[i].transform.position = points1[18].position;
                                    // points1[18].GetComponent<Image>().color = Color.red;
                                }
                                else
                                {
                                    Destroy(listP[i]);
                                    listP.RemoveAt(i);
                                    i--;
                                    var minus = TextObject.transform.Find("minus");
                                    if (minus != null)
                                    {
                                        var minusT = minus.GetComponent<Text>().text;
                                        var minusInt = Convert.ToInt32(minusT) + 1;
                                        minus.GetComponent<Text>().text = minusInt.ToString();
                                        Debug.Log("minus+1");
                                    }
                                }
                            }
                        }
                        else
                        {
                            for (int j = 18; j > 1; j--)
                            {
                                if (predP.transform.position == points1[j - 1].position)
                                {
                                    listP[i].transform.position = points1[j].position;
                                    points1[j].GetComponent<Image>().color = Color.red;
                                }

                            }
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
            sec += delta;
            if (sec < secMax + 1)
            {
                StartCoroutine(AddPeople());

                if (flag1 == -1)
                {
                    treatment -= delta;
                    if (treatment == 0)
                    {
                        flag1 = 1;
                        treatment = period;
                    }
                }
                StartCoroutine(ListPeople1());
            }
            yield return new WaitForSeconds(1);
        }

    }
}
