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
    private float y;

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
        Vector3[] spawns = new Vector3[3];

    

        spawns[0] = new Vector3(-9.18000031f, 2.61999989f, 6.36999989f);
        spawns[1] = new Vector3(-11.5600004f, 1.42999995f, 30.0200005f);
        spawns[2] = new Vector3(1.66999996f, 2.75f, 34.3199997f);


        Debug.Log(spawns.Length);
        int rs = UnityEngine.Random.Range(0, spawns.Length);
        //randSpawn = spawns[rs];
        this.transform.position = spawns[rs];
        y = this.transform.position.y;
        //return randSpawn;


    }

    public void appear()
    {
        // spawnSize();
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
        this.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0.38f, 0.38f, 0.38f), Time.deltaTime * speed);
    }

    void hovern()
    {
        if (hover == true)
        {
            float yPos = Mathf.PingPong(Time.time * 1, range) * hoverSpeed;
            Debug.Log(yPos);
            transform.position = new Vector3(transform.position.x, y + yPos, transform.position.z);
        }
    }
}
