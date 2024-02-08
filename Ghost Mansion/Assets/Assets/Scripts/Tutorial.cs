using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorial;
    public VideoPlayer video;
    public RawImage rawImage;

    public OVRInput.Button input;
    public bool tutOn;

    // Start is called before the first frame update
    void Start()
    {
        playVideo();
        tutOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        tutorialOff();
    }

    void tutorialOff()
    {
        if(OVRInput.Get(input))
        {
            tutorial.SetActive(false);
            tutOn = false;
        }
    }

    void playVideo()
    {
        video.Play();
    }
}
