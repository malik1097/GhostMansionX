using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

    public string interactTag;

    public GameObject particleSystem;

    public Boolean suck;

    public GameObject vacuum;
    public float shrinkSpeed;

    private bool colliding = false;
    private bool isCloseEnough;

    private bool blue = false;
    private bool red = false;
    private bool yellow = false;

    private AudioSource audioSource;

    [SerializeField] RedGhostBehaviour rgb;
    [SerializeField] YellowGhostBehaviour ygb;
    [SerializeField] BlueGhostBehaviour bgb;
    [SerializeField] Ghostcounter gc;
    //[SerializeField] Hover hvr;
    //[SerializeField] public GameObject prefab;

    private Vector3 randSpawn;
    public bool vacuumOn = false;


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
        //ghostAppear();
        //randomSpawnPosition();
        //ghostStart();
        vacuumVibrate();
    }

    public void catchGhost()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, maxRange))
        {
            lineRenderer.SetPosition(1, Vector3.forward * hit.distance);


            if (OVRInput.Get(b) && gc.end == false)
            {
                
                vacuumOn = true;

                if (hit.transform.tag.Contains(interactTag))
                {
                    Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                    rb.AddForce(-transform.forward * Time.deltaTime * speed, ForceMode.Force);
                }
                suck = true;
                

                //playAudio();

                if (hit.transform.tag.Contains(ghostTag))
                {
                    Rigidbody rb = hit.transform.GetComponent<Rigidbody>();
                    ygb.hover = false;
                    bgb.hover = false;
                    rgb.hover = false;


                    if (rb != null)
                    {
                        
                        //rb.AddForce(-transform.forward * Time.deltaTime * speed, ForceMode.Force);
                        //hit.transform.position -= transform.forward * Time.deltaTime * speed;

                        Vector3 ghostPos = hit.transform.position;
                        Vector3 vacuumPos = vacuum.transform.position;
                        Vector3 newScale = hit.transform.localScale;

                        float step = vacSpeed * Time.deltaTime;

                        hit.transform.position = Vector3.MoveTowards(ghostPos, vacuumPos, step);

                        //hit.transform.localScale *= 0.99f;
                        if (newScale.x >= 0.1f && newScale.y >= 0.1f && newScale.z >= 0.1f)
                        {
                            hit.transform.localScale *= 0.99f;
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
                    ygb.hover = true;
                    bgb.hover = true;
                    rgb.hover = true;
                    SetColor(Color.red);
                }
            }
            else
            {
                suck = false;
                SetColor(Color.cyan);
                vacuumOn = false;

                //rgb.y = hit.transform.position.y;
                //bgb.y = hit.transform.position.y;
                //ygb.y = hit.transform.position.y;

               
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
        float bclose = Vector3.Distance(this.transform.position, bgb.transform.position);
        float rclose = Vector3.Distance(this.transform.position, rgb.transform.position);
        float yclose = Vector3.Distance(this.transform.position, ygb.transform.position);

        if (bclose <= 7 && bclose < rclose && bclose < yclose)
        {
            
            blue = true;
            red = false;
            yellow = false;

            bgb.appear();
        }
        if (rclose <= 7 && rclose < bclose && rclose < yclose)
        {
            
            blue = false;
            red = true;
            yellow = false;

            rgb.appear();
        }
        if (yclose <= 7 && yclose < bclose && yclose < rclose)
        {
           
            blue = false;
            red = false;
            yellow = true;

            ygb.appear();
        }
    }


    public void respawn()
    {
        if(gc.eingesaugt)
        {
            if(blue = true)
            {
                bgb.backToSize();
                bgb.randomSpawnPosition();
            }
            if (red = true)
            {
                rgb.backToSize();
                rgb.randomSpawnPosition();
            }
            if (yellow = true)
            {
                ygb.backToSize();
                ygb.randomSpawnPosition();
            }
        }
    }

    public void vacuumVibrate()
    {
        if(OVRInput.Get(b))
        {
            OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
            particleSystem.SetActive(true);
        }
        else
        {
            OVRInput.SetControllerVibration(0, 0, OVRInput.Controller.RTouch);
            particleSystem.SetActive(false);
        }
    }

    public void ghostStart()
    {
        //Vector3 startPos = new Vector3(-0.4654015f, 2.26f, 13.28f);
        //ghost.SetActive(true);
        //Instantiate(prefab, randSpawn, Quaternion.identity);
        // prefab.GetComponent<MeshRenderer>().enabled = true;
    }

    //public void ghostStart()
    //{
    //    Vector3 startPos = new Vector3(-0.4654015f, 3.26f, 13.28f);
    //    ghost.SetActive(true);
    //    Instantiate(prefab, startPos, Quaternion.identity);
    //    Renderer renderChild = prefab.GetComponentInChildren().enabled = true;
    //    renderChild.enabled = true;
    //}

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.collider.tag == ghostTag)
    //    {
    //        collision.collider.transform.gameObject.SetActive(false);
    //    }
    //}
}
