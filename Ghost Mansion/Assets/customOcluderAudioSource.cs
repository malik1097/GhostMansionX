using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

 

[RequireComponent(typeof(AudioSource))]
public class customOcluderAudioSource : MonoBehaviour
{
    AudioSource audioSource;
    public AudioListener audioListener;

    public List<Collider> occluder;

    public UnityEvent<bool> ocludderCallback;
    public UnityEvent<float> angleCallback;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, audioListener.transform.position- transform.position);
        RaycastHit[] hits = Physics.RaycastAll(ray);
        bool found = false;
        for (int j = 0; j < hits.Length && !found; j++)
            for (int i = 0; i < occluder.Count && !found; i++)
                if (hits[j].collider == occluder[i])
                    found = true;
        ocludderCallback.Invoke(found);
        angleCallback.Invoke(Vector3.Angle(transform.forward, (audioListener.transform.position - transform.position).normalized));
    }
}