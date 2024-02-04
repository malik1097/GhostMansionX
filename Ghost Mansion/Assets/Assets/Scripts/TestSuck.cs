using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSuck : MonoBehaviour
{
    public GameObject vacuum;
    public int speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 ghostPos = this.transform.position;
        Vector3 vacuumPos = vacuum.transform.position;

        float step = speed * Time.deltaTime;

        this.transform.position = Vector3.MoveTowards(ghostPos, vacuumPos, step);
    }
}
