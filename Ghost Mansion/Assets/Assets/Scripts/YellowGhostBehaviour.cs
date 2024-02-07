using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowGhostBehaviour : MonoBehaviour
{

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

    

        spawns[0] = new Vector3(-0.692999959f, 1.28999996f, -5.80000019f);
        spawns[1] = new Vector3(-16.8999996f, 3, 0.0799999982f);
        spawns[2] = new Vector3(-22.1499996f, -0.419999987f, 15.8900003f);
        spawns[3] = new Vector3(-21.9599991f, 2.22000003f, 29.7999992f);
        spawns[4] = new Vector3(-10.71f, 3.01999998f, 19.4400005f);
        spawns[5] = new Vector3(-7.34000015f, 1.90999997f, 30.9699993f);
        spawns[6] = new Vector3(4.73000002f, -0.469999999f, 21.5799999f);
        spawns[7] = new Vector3(4.73000002f, 2.98000002f, 11.0699997f);
        spawns[8] = new Vector3(-7.65999985f, 2.96000004f, 9.60000038f);
        spawns[9] = new Vector3(-2.49000001f, 2.49000001f, 19.0699997f);

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

    public void backToSize()
    {
        this.transform.localScale = new Vector3(0.38f, 0.38f, 0.38f);

    }

    public void spawnSize()
    {
        this.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0.38f, 0.38f, 0.38f), Time.deltaTime * speed);
    }
}
