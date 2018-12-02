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

    [SerializeField, Tooltip("Child of Canvas object")]
    Button soundButton;

    [SerializeField]
    Sprite[] soundSprites;

    private void Awake()
    {
        EventManager.EventMenuLoaded += OnMenuLoaded;
    }

    void Start ()
    {
        //PlayerPrefsManager.LockAllCars();
        //PlayerPrefsManager.SetNumberOfCoins(15000);
        if(PlayerPrefsManager.IsSoundOn())
        {
            soundButton.GetComponent<Image>().sprite = soundSprites[1];
            AudioListener.volume = 1;
        }
        else if (!PlayerPrefsManager.IsSoundOn())
        {
            soundButton.GetComponent<Image>().sprite = soundSprites[0];
            AudioListener.volume = 0;
        }
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

    void OnCoinSubstracted()
    {
        coins.text = PlayerPrefsManager.GetNumberOfCoins().ToString();
    }

    public void AddEvent()
    {
        EventManager.EventCoinSubstracted += OnCoinSubstracted;
    }

    public void ClearEvent()
    {
        EventManager.EventCoinSubstracted -= OnCoinSubstracted;
    }

    public void ToggleSound()
    {
        if (  Application.platform != RuntimePlatform.Android) { return; }

        if (PlayerPrefsManager.IsSoundOn())
        {
            AudioListener.volume = 0;
            soundButton.GetComponent<Image>().sprite = soundSprites[0];
            PlayerPrefsManager.SetSoundOff();
        }
        else if (!PlayerPrefsManager.IsSoundOn())
        {
            AudioListener.volume = 1;
            soundButton.GetComponent<Image>().sprite = soundSprites[1];
            PlayerPrefsManager.SetSoundOn();
        }
    }
}
