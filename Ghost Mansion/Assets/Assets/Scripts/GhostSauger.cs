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
     public ParticleSystem particleSystem;

    void SetColor(Color c)
    {
        debugPlane.GetComponent<Renderer>().materials[0].color = c;
    }

    void Start()
    {
        particleSystem.gameObject.SetActive(false);
    }

    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {
            lineRenderer.SetPosition(1, Vector3.forward * hit.distance);

            if (OVRInput.Get(b))
            {
                particleSystem.gameObject.SetActive(true);
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
                particleSystem.gameObject.SetActive(false);
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
