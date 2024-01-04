using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HMDInfo : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Is Device Active: " + XRSettings.isDeviceActive);
        Debug.Log("Device Name is : " + XRSettings.loadedDeviceName);

        if(!XRSettings.isDeviceActive)
        {
            Debug.Log("Noo Headset plugged");
        }
        else if (XRSettings.isDeviceActive && (XRSettings.loadedDeviceName == "Mock HMD" || XRSettings.loadedDeviceName == "MockHMD Display"))
        {
            Debug.Log("Using HMD");
        }
        else
        {
            Debug.Log("Headset : " + XRSettings.loadedDeviceName);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
