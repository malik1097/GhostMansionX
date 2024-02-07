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
        Vector3[] spawns = new Vector3[3];

        spawns[0] = new Vector3(-5.76999998f, 4.57999992f, 26.5100002f);
        spawns[1] = new Vector3(17.9899998f, 1.14999998f, 27.8700008f);
        spawns[2] = new Vector3(14.9200001f, 1.45000005f, 16f);


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
