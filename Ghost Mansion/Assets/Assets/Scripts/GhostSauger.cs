using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GhostSauger : MonoBehaviour
{
    public float speed;
    public float vacSpeed;
    public float maxRange;
    public string ghostTag;
    public OVRInput.Button b;
    public GameObject debugPlane;
    public LineRenderer lineRenderer;

    public GameObject particleSystem;

    public Boolean suck;

    public GameObject vacuum;
    public float shrinkSpeed;

    private bool colliding = false;
    private bool isCloseEnough;

    private AudioSource audioSource;

    [SerializeField] GhostBehaviour gb;



    void SetColor(Color c)
    {
        debugPlane.GetComponent<Renderer>().materials[0].color = c;
    }

    void Start()
    {
        particleSystem.SetActive(false);
    }

    void Update()
    {
        catchGhost();
        closeEnough();
        ghostAppear();
    }

    public void catchGhost()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {
            lineRenderer.SetPosition(1, Vector3.forward * hit.distance);


            if (OVRInput.Get(b))
            {
                suck = true;
                particleSystem.SetActive(true);

                //playAudio();

                if (hit.transform.tag.Contains(ghostTag))
                {
                    Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                    if (rb != null)
                    {
                        //rb.AddForce(-transform.forward * Time.deltaTime * speed, ForceMode.Force);
                        //hit.transform.position -= transform.forward * Time.deltaTime * speed;

                        Vector3 ghostPos = hit.transform.position;
                        Vector3 vacuumPos = vacuum.transform.position;
                        Vector3 newScale = hit.transform.localScale;

                        float step = vacSpeed * Time.deltaTime;

                        hit.transform.position = Vector3.MoveTowards(ghostPos, vacuumPos, step);

                        newScale *= 0.99f;
                        if (newScale.x >= 0.1f && newScale.y >= 0.1f && newScale.z >= 0.1f)
                        {
                            newScale *= 0.99f;
                        }
                        //float distance = Vector3.Distance(hit.transform.position, vacuum.transform.position);
                        //float shrinkTime = distance / shrinkSpeed;

                        //Vector3 newScale = hit.transform.localScale;
                        //newScale *= 0.99f;

                        ////yield return new WaitForSeconds(shrinkTime);


                        //if(newScale.x <= 0.1f && newScale.y <= 0.1f && newScale.z <= 0.1f)
                        //{

                        //}



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
                suck = false;
                SetColor(Color.cyan);
                particleSystem.SetActive(false);
                //stopAudio();
               
            }
        }
        else
        {
            lineRenderer.SetPosition(1, Vector3.forward * maxRange);
            SetColor(Color.white);
        }
    }

    //public void playAudio()
    //{
    //    audioSource.GetComponent<AudioSource>().Play();
    //}

    //public void stopAudio()
    //{
    //    audioSource.GetComponent<AudioSource>().Stop();
    //}

    void closeEnough()
    {
        float close = Vector3.Distance(this.transform.position, gb.transform.position);
        if (close <= 50)
        {
            isCloseEnough = true;
        }
    }

    void ghostAppear()
    {
        if (isCloseEnough)
        {
            gb.appear();
        }
    }


    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.tag == ghostTag)
    //    {
    //        collision.collider.transform.gameObject.SetActive(false);
    //    }
    //}
}
