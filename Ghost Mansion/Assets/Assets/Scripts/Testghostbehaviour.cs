using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testghostbehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 defaultScale = new Vector3(0.38f, 0.38f, 0.38f); 
        if (transform.localScale.x < defaultScale.x)
        {
            transform.localScale *= 1.001f; // You can adjust the growth rate as needed
        }
    }
}
