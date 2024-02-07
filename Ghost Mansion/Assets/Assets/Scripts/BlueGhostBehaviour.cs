using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class BlueGhostBehaviour : MonoBehaviour
{
    //GameObject ghost;
    //public GameObject prefab;
    private Vector3 randSpawn;
    public int speed;
    

    // Start is called before the first frame update
    void Start()
    {
        disappear();
        //randomStartposition();
        randomSpawnPosition();
        //ghostStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    /* public void randomStartposition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-20, 20), Random.Range(-5, 20), Random.Range(2, 6));
    } */

    public void randomSpawnPosition()
    {
        //foreach (Transform child in transform)
        //{
        //    MeshRenderer renderer = child.GetComponent<MeshRenderer>();

        //    if (renderer != null)
        //    {
        //        renderer.enabled = true;
        //    }
        //}
        Vector3[] spawns = new Vector3[10];

        spawns[0] = new Vector3(8.46000004f, 1.0999999f, 28.8600006f);
        spawns[1] = new Vector3(0.0900000036f, 1.75f, 24.5499992f);
        spawns[2] = new Vector3(13.3310003f, 1.38f, 15.5570002f);
        spawns[3] = new Vector3(-19.6599998f, 1.58000004f, 6.71999979f);
        spawns[4] = new Vector3(-20.2000008f, -0.449999988f, 27.4200001f);
        spawns[5] = new Vector3(-3.79999995f, 0.939999998f, 25.6700001f);
        spawns[6] = new Vector3(-3.80800009f, 0.859000027f, 7.82299995f);
        spawns[7] = new Vector3(-10.8199997f, -0.629999995f, 0.50999999f);
        spawns[8] = new Vector3(2.70799994f, -0.629999995f, -6.16699982f);
        spawns[9] = new Vector3(-1.73000002f, 1.28999996f, 3.24000001f);

        Debug.Log(spawns.Length);
        int rs = UnityEngine.Random.Range(0, spawns.Length);
        //randSpawn = spawns[rs];
        this.transform.position = spawns[rs];

        //return randSpawn;


    }

    public void appear()
    {
        spawnSize();
        foreach (Transform child in transform)
        {
            MeshRenderer renderer = child.GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                renderer.enabled = true;
            }
        }
    }

    public void disappear()
    {
        //this.gameObject.SetActive(false);
        foreach (Transform child in transform)
        {
            MeshRenderer renderer = child.GetComponent<MeshRenderer>();

            if (renderer != null)
            {
                renderer.enabled = false;
            }
        }
    }

    public Vector3 getPosition()
    {
        return this.transform.position;
    }

    public void backToSize()
    {
        this.transform.localScale = new Vector3(0.38f, 0.38f, 0.38f);

    }

    public void spawnSize()
    {
        this.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0.38f, 0.38f, 0.38f), Time.deltaTime * speed);
    }

}
