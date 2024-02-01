using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSauger : MonoBehaviour
{
    public float speed;
    public float maxRange;
    public string ghostTag;
    public OVRInput.Button b;
    public GameObject debugPlane;
    public LineRenderer lineRenderer;

    void SetColor(Color c)
    {
        debugPlane.GetComponent<Renderer>().materials[0].color = c;
    }

    void Start()
    {
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {
            lineRenderer.SetPosition(1, Vector3.forward * hit.distance);

            if (OVRInput.Get(b))
            {
                //Vibrator
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                

                if (hit.transform.tag.Contains(ghostTag))
                {
                    Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        rb.AddForce(-transform.forward * Time.deltaTime * speed, ForceMode.Force);
                        SetColor(Color.green);
                        
                    }
                    else
                    {
                        SetColor(Color.magenta);
                    }
                }
                else
                {
                    
                    SetColor(Color.red);
                }
            }
            else
            {
                    //Vibrator off
                    OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
                SetColor(Color.cyan);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, Vector3.forward * maxRange);
            SetColor(Color.white);
        }

    }
}
