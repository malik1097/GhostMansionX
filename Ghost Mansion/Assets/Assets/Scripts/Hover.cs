using UnityEngine;
using System.Collections;


public class Hover : MonoBehaviour {


    public float amplitude = 0.1f;
    public float frequency = 0.5f;

    public bool hover = true;


    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();


    void Start ()
    {
        posOffset = transform.position;
    }


    void Update ()
    {
        hovern();
    }

    void hovern()
    {
        if(hover == true)
        {
            tempPos = posOffset;
            tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;

            transform.position = tempPos;
        }
        else
        {
            transform.position = posOffset;
        }
    }
}