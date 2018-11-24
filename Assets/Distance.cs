using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour {

    [SerializeField]
    GameObject player;

    private Text text;
    private float distance;
	// Use this for initialization
	void Start () {
        text = GetComponent<Text>();
        text.text = "0";
    }
	
	// Update is called once per frame
	void Update () {
        distance = Mathf.Round((player.transform.position.z+129f) * 100f) / 100f;
        text.text = distance.ToString();
    }
}
