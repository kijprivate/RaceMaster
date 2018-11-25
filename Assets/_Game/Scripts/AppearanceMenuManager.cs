using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceMenuManager : MonoBehaviour {

    [SerializeField]
    GameObject player;

    [SerializeField]
    Mesh[] sprites;

    void Awake()
    {
        EventManager.EventChooseCar += OnChooseCar;
    }

    private void Start()
    {
        player.transform.GetChild(0).GetComponent<MeshFilter>().mesh = sprites[PlayerPrefsManager.GetChoosenCarNumber()];
    }
    void OnChooseCar(int choosenCar)
    {
        player.transform.GetChild(0).GetComponent<MeshFilter>().mesh = sprites[choosenCar];
    }

    public void ClearEvent()
    {
        EventManager.EventChooseCar -= OnChooseCar;
    }
}
