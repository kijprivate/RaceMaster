using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour {

    [SerializeField]
    GameObject crashParticle;

    [SerializeField]
    float speed = 5f;

    Rigidbody rigidBody;
    Animator animator;
    AudioSource audioSource;

    bool isDriving = true;
    bool gameOver = false;
    Vector3 lastPos;
	// Use this for initialization
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponentInParent<AudioSource>();
       // rigidBody.AddForce(Vector3.forward * speed);

        animator = GetComponentInParent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (isDriving)
        {
            this.transform.parent.transform.position += new Vector3(0f,0f, speed * Time.deltaTime);
            lastPos = this.transform.position;
        }

	}
    private void OnCollisionEnter(Collision other)
    {
        //print("trigger");
        if (other.gameObject.tag == "FrontCollider" && !gameOver)
        {
            print("front");
            isDriving = false;
            animator.SetTrigger("FrontCollision");
            this.transform.parent.transform.position = lastPos;

            ContactPoint contact = other.contacts[0];
            Instantiate(crashParticle, contact.point, Quaternion.identity);
 
            audioSource.Play();
            gameOver = true;
        }
        if (other.gameObject.tag == "LeftCollider" && !gameOver)
        {
            isDriving = false;
            animator.SetTrigger("LeftCollision");
            this.transform.parent.transform.position = lastPos;

            ContactPoint contact = other.contacts[0];
            Instantiate(crashParticle, contact.point, Quaternion.identity);

            audioSource.Play();
            gameOver = true;
        }
        if (other.gameObject.tag == "RightCollider" && !gameOver)
        {
            isDriving = false;
            animator.SetTrigger("RightCollision");
            this.transform.parent.transform.position = lastPos;

            ContactPoint contact = other.contacts[0];
            Instantiate(crashParticle, contact.point, Quaternion.identity);

            audioSource.Play();
            gameOver = true;
        }
    }

}
