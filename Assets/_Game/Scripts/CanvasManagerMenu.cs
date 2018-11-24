using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManagerMenu : MonoBehaviour {

    [Header("Menu Scene")]
    [SerializeField,Tooltip("Child of Canvas object")]
    Text highScore;

    [SerializeField,Tooltip("Child of Canvas object")]
    Text gamesPlayed;

    [SerializeField, Tooltip("Child of Canvas object")]
    Text coins;

    private void Awake()
    {
        EventManager.EventMenuLoaded += OnMenuLoaded;
    }

    void Start ()
    {
        EventManager.RaiseEventMenuLoaded();
    }
    
    void OnMenuLoaded()
    {
        //display values in UI
        highScore.text = "HIGH SCORE: "+PlayerPrefsManager.GetHighScore();
        gamesPlayed.text = "GAMES PLAYED: "+PlayerPrefsManager.GetGamesPlayed();
        coins.text = PlayerPrefsManager.GetNumberOfCoins().ToString();

        EventManager.EventMenuLoaded -= OnMenuLoaded;
    }

}
