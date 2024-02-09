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


    public float amplitude = 0.1f;
    public float frequency = 0.5f;

    public bool hover = true;
    public float range;
    public float hoverSpeed;
    public float y;

    public Transform player;
    public float followSpeed = 5f;

    Vector3 posOffset = new Vector3();
    Vector3 tempPos = new Vector3();
    // Start is called before the first frame update
    void Start()
    {
        disappear();
        //randomStartposition();
        randomSpawnPosition();
        //ghostStart();
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        hovern();
        faceAt();
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

        spawns[0] = new Vector3(-8.99600029f, 1.38f, 10.21f);
        spawns[1] = new Vector3(2.42000008f, 3.04999995f, 19.7000008f);
        spawns[2] = new Vector3(17.9899998f, 3.1400001f, 33.3300018f);
        spawns[3] = new Vector3(10.1099997f, 3.04999995f, 37.7700005f);
        spawns[4] = new Vector3(16.9899998f, 4.63999987f, 17.6800003f);
        spawns[5] = new Vector3(-2.5f, 3.05999994f, 19.9799995f);
        spawns[6] = new Vector3(-14.2200003f, 1.79999995f, 23.5699997f);
        spawns[7] = new Vector3(-18.1700001f, 1.75f, 37.4199982f);
        spawns[8] = new Vector3(4.45800018f, 1.546f, 3.47000003f);
        spawns[9] = new Vector3(6.28999996f, 5.38999987f, 12.6999998f);


        Debug.Log(spawns.Length);
        int rs = UnityEngine.Random.Range(0, spawns.Length);
        //randSpawn = spawns[rs];
        this.transform.position = spawns[rs];
        y = this.transform.position.y;
        //return randSpawn;


    }

    public void appear()
    {
        //spawnSize();
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
        Vector3 newScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(1, 1, 1), Time.deltaTime * speed);
        this.transform.localScale = newScale;
    }

    void hovern()
    {
        if (hover == true)
        {
            float yPos = Mathf.PingPong(Time.unscaledTime * 1, range) * hoverSpeed;
            Debug.Log(yPos);
            transform.position = new Vector3(transform.position.x, y + yPos, transform.position.z);
        }
        else
        {
            y = this.transform.position.y;
        }
    }

    void faceAt()
    {
        Vector3 direction = player.position - this.transform.position;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, followSpeed * Time.deltaTime);
    }
}
