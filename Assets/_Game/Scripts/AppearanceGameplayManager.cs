using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearanceGameplayManager : MonoBehaviour {

    [SerializeField,Tooltip("Player's body")]
    GameObject player;

    [SerializeField]
    Mesh[] sprites;

    private void Start()
    {
        player.transform.GetChild(0).GetComponent<MeshFilter>().mesh = sprites[PlayerPrefsManager.GetChoosenCarNumber()];
    }
}
