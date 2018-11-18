using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    [SerializeField]
    float speed = 5f;

    Rigidbody rigidBody;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = new Vector3(0f, 0f, speed);
	}
	
	// Update is called once per frame
	void Update () {
        //this.transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);

	}
}
