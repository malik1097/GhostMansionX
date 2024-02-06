using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractObject : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public OVRInput.Button b;
    public float maxRange;
    public string interactTag;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {
            lineRenderer.SetPosition(1, Vector3.forward * hit.distance);


            if (OVRInput.Get(b))
            {
                if (hit.transform.tag.Contains(interactTag))
                {
                    Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                    //rb.
                }
            }
        }
        else
        {
            lineRenderer.SetPosition(1, Vector3.forward * maxRange);
        }
    }
}
