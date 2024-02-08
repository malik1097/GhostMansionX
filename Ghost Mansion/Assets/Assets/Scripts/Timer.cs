using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn = false;

    public TextMeshProUGUI TimerTxt;

    [SerializeField] Tutorial tutorial;

    // Start is called before the first frame update
    void Start()
    {
        TimerOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(tutorial.tutOn == false)
        {

            updateTimer(TimeLeft);

            if (TimerOn)
            {
                if(TimeLeft > 0)
                {
                    TimeLeft -= Time.deltaTime;
                
                }
                else{
                    TimeLeft = 0;
                    //TimerOn = false;
               

                }
            }

        }

    }

    void updateTimer(float currentTime)
    {
       
        float minutes = Mathf.FloorToInt(currentTime / 60);
        float seconds = Mathf.FloorToInt(currentTime % 60);

        TimerTxt.text = string.Format("{0:00} : {1:00}", minutes, seconds);

    }
}
