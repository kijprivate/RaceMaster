using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasManager : MonoBehaviour {

    [SerializeField]
    Button playAgain;

    [SerializeField]
    MoveForward player;
	// Use this for initialization
	void Start () {
        playAgain.GetComponentInChildren<Text>().enabled = false;
        playAgain.image.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.gameOver)
        {
            playAgain.GetComponentInChildren<Text>().enabled = true;
            playAgain.image.enabled = true;
        }
	}
}
