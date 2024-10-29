using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Cub : MonoBehaviour
{
    public Transform startP;
    //public Vector3 endP;
    public int tX;
    public int tY;
    Vector2 rt;
    public float speed;
    private float progress;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        //rt.x = startP.position.x;
       // rt.y= startP.position.y;
        // transform.position=Vector2.Lerp(rt, endP, progress);
        //transform.rotation = Quaternion.identity;
        //progress += speed;
        var otherPosn = startP.position;
        if (otherPosn.x < -28) { tX *= -1; otherPosn.x = -22; }
        if (otherPosn.x > 28) { tX *= -1; otherPosn.x = 22; }
        if (otherPosn.y < -18) { tY *= -1; otherPosn.y = -13; }
        if (otherPosn.y > 18) { tY *= -1; otherPosn.y = 13;  }
        startP.position = new Vector3(otherPosn.x, otherPosn.y, -80);
        Vector3 vectP=new Vector3(tX,tY,0);
        transform.Translate(vectP.normalized*speed);
        //transform.Translate(vectP*speed*Time.deltaTime);
        transform.Rotate(tX, tY,0);
        

    }
    private void OnCollisionEnter(Collision collision)
    {

        var yu = collision.contacts[0].normal;
        if (Convert.ToInt32(yu.x) != 0) { tX *= -1; }
        if (Convert.ToInt32(yu.y) != 0) { tY *= -1; }
       // Vector3 vectP = new Vector3(tX, tY,0);
       // transform.Translate(vectP.normalized * 40);
        //int rf = tX;
        //tX = Convert.ToInt32( yu.x);
        // tY = Convert.ToInt32(yu.y);
        // tZ = yu.z;
       // print("Casanie:"+ Convert.ToInt32(yu.x)+";"+ Convert.ToInt32(yu.y)); 

    }

}
