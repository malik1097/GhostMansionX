using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGhostBehaviour : MonoBehaviour
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

    

        spawns[0] = new Vector3(3.4000001f, 5f, 37.8699989f);
        spawns[1] = new Vector3(-4.69000006f, 1.96000004f, 37.8699989f);
        spawns[2] = new Vector3(-18.1299992f, 3.42000008f, 16.4799995f);
        spawns[3] = new Vector3(-9.18000031f, 2.61999989f, 6.36999989f);
        spawns[4] = new Vector3(-11.5600004f, 1.42999995f, 30.0200005f);
        spawns[5] = new Vector3(1.66999996f, 2.75f, 34.3199997f);
        spawns[6] = new Vector3(8.76500034f, 2.5f, 2.3599999f);
        spawns[7] = new Vector3(-17.8899994f, 4.19999981f, 27.25f);
        spawns[8] = new Vector3(-0.230000004f, 3.56999993f, 12.1499996f);
        spawns[9] = new Vector3(11.6599998f, 1.42999995f, 20.0499992f);




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
