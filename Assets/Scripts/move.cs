using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class move : MonoBehaviour
{
    public Transform t;
    private float x0;
    // Start is called before the first frame update
    void Start()
    {
        x0 = this.GetComponent<Transform>().position.x;
        //Debug.Log(x0);
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 temp = new Vector3(  (float)Math.Floor(Time.time * 2)*0.25f %21 + (-27f - x0), 0, 0);
        //this.GetComponent<Transform>().position = temp;

        //Con un if si ha pasado 1 seg o setposition
        if ( Math.Floor(Time.time - Time.deltaTime) < Math.Floor(Time.time))
        {
            this.GetComponent<Transform>().Translate(new Vector3(0.5f, 0, 0));
        }
        if (this.GetComponent<Transform>().position.x > 12.5) this.GetComponent<Transform>().Translate(new Vector3(-27f, 0, 0));
        //float t = Time.deltaTime;
    }
}
