using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

    AudioSource audioSource;

    bool increaseVolume = false;

    private void Awake()
    {
        EventManager.EventGameStarted += OnGameStarted;
    }
    void Start () {
        audioSource = GetComponent<AudioSource>();
	}

    private void Update()
    {
        if(increaseVolume && audioSource.volume < 0.5f)
        {
            audioSource.volume += 0.01f;
        }   
    }

    void OnGameStarted()
    {
        audioSource.Play();
        increaseVolume = true;
        EventManager.EventGameStarted -= OnGameStarted;
    }
}
