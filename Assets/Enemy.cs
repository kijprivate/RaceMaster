using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
        transform.Rotate(new Vector3(0.0f, 180.0f, 0.0f));
       // this.GetComponent<Rigidbody>().AddForce(Vector3.forward*4f);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += Vector3.back;
	}
}
