using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManagerGameplay : MonoBehaviour {

    [Header("Gameplay Scene")]
    [SerializeField, Tooltip("Child of Canvas object")]
    Button playAgain;

    [SerializeField]
    MoveForward player;

    [SerializeField, Tooltip("Child of Canvas object")]
    Text coins;

    private void Awake()
    {
        EventManager.EventGameplayLoaded += OnGameplayLoaded;
        EventManager.EventCoinCollected += OnCoinCollected;
        coins.text = 0.ToString();
    }

    void Start ()
    {
        EventManager.RaiseEventGameplayLoaded();
    }
	
	void Update () {
        if (SceneManager.GetActiveScene().name == "Gameplay")  //todo handle it in ongameover event
        {
            if (player.gameOver)
            {
                playAgain.GetComponentInChildren<Text>().enabled = true;
                playAgain.image.enabled = true;
            }
        }
    }

    void OnGameplayLoaded()
    {
        //hide play again button
        playAgain.GetComponentInChildren<Text>().enabled = false;
        playAgain.image.enabled = false;
    }

    void OnCoinCollected()
    {
        coins.text = CollectiblesHandler.Coins.ToString();
    }
}
