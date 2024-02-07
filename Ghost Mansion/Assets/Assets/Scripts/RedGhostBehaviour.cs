using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class RedGhostBehaviour : MonoBehaviour
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

        spawns[0] = new Vector3(5.19000006f, -0.600000024f, -5.78000021f);
        spawns[1] = new Vector3(12.8100004f, -0.600000024f, 6.51000023f);
        spawns[2] = new Vector3(0.0799999982f, 0.889999986f, 26.9400005f);
        spawns[3] = new Vector3(0.49000001f, 1.21000004f, 9.94999981f);
        spawns[4] = new Vector3(-19.2399998f, 2.8499999f, 16.7099991f);
        spawns[5] = new Vector3(-6.46999979f, 0.0599999987f, 28.5699997f);
        spawns[6] = new Vector3(-4.01000023f, 1.48000002f, 10.3100004f);
        spawns[7] = new Vector3(-11.0200005f, 2.51999998f, -8.10999966f);
        spawns[8] = new Vector3(16.7700005f, -1, 18.2600002f);
        spawns[9] = new Vector3(15.7799997f, 1.10000002f, 28.8600006f);

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
        this.transform.localScale = Vector3.Lerp(new Vector3(0, 0, 0), new Vector3(0.38f, 0.38f, 0.38f), Time.deltaTime * speed);
    }
}
