using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Rendering;

public class RedGhostBehaviour : MonoBehaviour
{
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
        //    {suck
        //        renderer.enabled = true;
        //    }
        //}
        Vector3[] spawns = new Vector3[10];

        spawns[0] = new Vector3(-5.76999998f, 4.57999992f, 26.5100002f);
        spawns[1] = new Vector3(17.9899998f, 1.14999998f, 27.8700008f);
        spawns[2] = new Vector3(14.9200001f, 1.45000005f, 16f);
        spawns[3] = new Vector3(-11.0200005f, 3.74000001f, 16.5400009f);
        spawns[4] = new Vector3(-7.65999985f, 3.96000004f, 3.04999995f);
        spawns[5] = new Vector3(3.76999998f, 3.96000004f, 6.94999981f);
        spawns[6] = new Vector3(17.4599991f, 1.25f, 21.3899994f);
        spawns[7] = new Vector3(17.2199993f, 2.67000008f, 38.1199989f);
        spawns[8] = new Vector3(8.03999996f, 3.54999995f, 26.7399998f);
        spawns[9] = new Vector3(-11.1199999f, 3.54999995f, 37.1300011f);


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
        foreach(Transform child in transform)
        {
            MeshRenderer renderer = child.GetComponent<MeshRenderer>();

            if(renderer != null)
            {
                renderer.enabled = false;
            }
        }
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
