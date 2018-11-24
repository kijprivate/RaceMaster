using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManagerGameplay : MonoBehaviour {

    [Header("Gameplay Scene")]
    [SerializeField, Tooltip("Child of Canvas object")]
    Button playAgain;

    [SerializeField, Tooltip("Child of Canvas object")]
    Button menu;

    [SerializeField, Tooltip("Child of Canvas object")]
    Text distance;

    [SerializeField, Tooltip("Child of Canvas object")]
    Text coins;

    [SerializeField, Tooltip("Player's body")]
    MoveForwardAndCollision player;

    [SerializeField, Tooltip("It depends on player's starting position.Sum of this value and player's position on 'z' axis should be 0")]
    float playerPositionOffset = 129f;

    float countDistance = 0;

    private void Awake()
    {
        EventManager.EventGameplayLoaded += OnGameplayLoaded;
        EventManager.EventCoinCollected += OnCoinCollected;
        EventManager.EventGameOver += OnGameOver;
        coins.text = 0.ToString();
    }

    void Start ()
    {
        EventManager.RaiseEventGameplayLoaded();
        distance.text = countDistance.ToString();
    }
	
	void Update ()
    {
        countDistance = Mathf.Round((player.transform.parent.transform.position.z + playerPositionOffset) * 100f) / 100f;
        distance.text = countDistance.ToString();
    }

    void OnGameplayLoaded()
    {
        HideButtons();
    }

    void OnCoinCollected()
    {
        coins.text = CollectiblesHandler.Coins.ToString();
    }

    void OnGameOver()
    {
        ShowButtons();

        if (countDistance > PlayerPrefsManager.GetHighScore())
        { PlayerPrefsManager.SetHighScore(countDistance); }

        EventManager.EventGameplayLoaded -= OnGameplayLoaded;
        EventManager.EventCoinCollected -= OnCoinCollected;
        EventManager.EventGameOver -= OnGameOver;
    }

    private void ShowButtons()
    {
        playAgain.GetComponentInChildren<Text>().enabled = true;
        playAgain.image.enabled = true;

        menu.GetComponentInChildren<Text>().enabled = true;
        menu.image.enabled = true;
    }

    private void HideButtons()
    {
        playAgain.GetComponentInChildren<Text>().enabled = false;
        playAgain.image.enabled = false;

        menu.GetComponentInChildren<Text>().enabled = false;
        menu.image.enabled = false;
    }
}
