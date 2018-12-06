using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingTruckSoundTrigger : MonoBehaviour {

    AudioSource audioSource;
	// Use this for initialization
	void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            audioSource.Play();
        }
    }
}
