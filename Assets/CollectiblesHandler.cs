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
    }

    void OnCoinCollected()
    {
        Coins += coinValue;
    }
}
