using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostBehaviour : MonoBehaviour
{
    public GameObject ghost;
    

    // Start is called before the first frame update
    void Start()
    {
        disappear();
        randomStartposition();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void randomStartposition()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-20, 20), Random.Range(-5, 20), Random.Range(2, 6));
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
}
