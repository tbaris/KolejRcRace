using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carpisma : MonoBehaviour {

    public AudioClip carpma;
    AudioSource ses;


    void Start()
    {
        ses = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        ses.PlayOneShot(carpma, 0.2F);
    }
}
