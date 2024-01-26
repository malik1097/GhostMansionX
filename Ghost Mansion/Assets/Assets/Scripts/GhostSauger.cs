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

    public GameObject player;

    [SerializeField] GhostBehaviour ghostBehaviour;

    

    void Start()
    {
    }

    void Update()
    {
        catchGhost();

    }


    void SetColor(Color c)
    {
        debugPlane.GetComponent<Renderer>().materials[0].color = c;
    }


    void catchGhost()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {
            lineRenderer.SetPosition(1, Vector3.forward * hit.distance);

            if (OVRInput.Get(b))
            {
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
                SetColor(Color.cyan);
            }
        }
        else
        {
            lineRenderer.SetPosition(1, Vector3.forward * maxRange);
            SetColor(Color.white);
        }
    }

    Vector3 getPlayerPosition()
    {
        return player.transform.position;
    }

    void letGhostAppear()
    {
        Vector3 playerPos = getPlayerPosition();
        Vector3 ghostPos = ghostBehaviour.getPosition();

        float distance = Vector3.Distance(playerPos, ghostPos);

        //if()
    }
}
