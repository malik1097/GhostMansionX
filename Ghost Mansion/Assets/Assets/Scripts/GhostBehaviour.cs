using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;


public class GhostBehaviour : MonoBehaviour
{
    GameObject ghost;
    

    // Start is called before the first frame update
    void Start()
    {
        disappear();
        //randomStartposition();
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
        Vector3[] spawns = new Vector3[5];

        spawns[0] = new Vector3(-10.85048f, -1.865619f, 6.553421f);
        spawns[1] = new Vector3(-9.792572f, -0.2184101f, 9.876396f);
        spawns[2] = new Vector3(1.442768f, 2.088465f, 19.90268f);
        spawns[4] = new Vector3(14.74884f, -0.003983911f, 16.1106f);
        spawns[5] = new Vector3(-18.97742f, 0.5934364f, 20.27015f);


        int rs = new Random.Range(0, spawns.Length);

        ghost.SetPosition(spawns[rs]);


    }

    public void disappear()
    {
        ghost.SetActive(false);
    }

    public void appear()
    {
        ghost.SetActive(true);
    }

    public Vector3 getPosition()
    {
        return this.transform.position;
    }

    public void SetPosition(Vector3 position)
    {
        this.transform.position = position;
    }
}
