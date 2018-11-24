using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblesHandler : MonoBehaviour {

    [Tooltip("Number of coins in active game")]
    public static int Coins=0;

    private int coinValue=1;

    private void Awake()
    {
        EventManager.EventCoinCollected += OnCoinCollected;
        EventManager.EventGameOver += OnGameOver;
        Coins = 0;
    }

    void OnCoinCollected()
    {
        Coins += coinValue;
    }

    void OnGameOver()
    {
        PlayerPrefsManager.SetNumberOfCoins(PlayerPrefsManager.GetNumberOfCoins() + Coins);
        PlayerPrefsManager.SetGamesPlayed(PlayerPrefsManager.GetGamesPlayed() + 1);

        EventManager.EventCoinCollected -= OnCoinCollected;
        EventManager.EventGameOver -= OnGameOver;

        Coins = 0;
    }
}
