using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForwardAndCollision : MonoBehaviour {

    [SerializeField]
    GameObject crashParticle;

    [SerializeField]
    float speed = 20f;

    Animator animator;
    AudioSource audioSource;

    float parentDistance;
    bool isDriving = false;
    public bool gameOver = false;
    Vector3 lastPos;

    private void Awake()
    {
        EventManager.EventGameOver += OnGameOver;
    }

    void Start () {
        parentDistance = GetComponentInParent<Transform>().position.z;
        audioSource = GetComponentInParent<AudioSource>();

        animator = GetComponentInParent<Animator>();
	}
	
	void Update ()
    {
        if(GetComponentInParent<Transform>().position.z - parentDistance > 100f && speed < 30f)
        {
            speed += 1f;
            parentDistance = GetComponentInParent<Transform>().position.z;
        }
        if(Input.GetMouseButton(0) && !gameOver && !isDriving)
        {
            isDriving = true;
            EventManager.RaiseEventGameStarted();
        }

        if (isDriving)
        {
            this.transform.parent.transform.position += new Vector3(0f,0f, speed * Time.deltaTime);
            lastPos = this.transform.position;
        }
	}

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "FrontCollider" && !gameOver)
        {
            animator.SetTrigger("FrontCollision");

            ContactPoint contact = other.contacts[0];
            Instantiate(crashParticle, contact.point, Quaternion.identity);

            EventManager.RaiseEventGameOver();
        }
        if (other.gameObject.tag == "LeftCollider" && !gameOver)
        {
            animator.SetTrigger("LeftCollision");

            ContactPoint contact = other.contacts[0];
            Instantiate(crashParticle, contact.point, Quaternion.identity);

            EventManager.RaiseEventGameOver();
        }
        if (other.gameObject.tag == "RightCollider" && !gameOver)
        {
            animator.SetTrigger("RightCollision");

            ContactPoint contact = other.contacts[0];
            Instantiate(crashParticle, contact.point, Quaternion.identity);

            EventManager.RaiseEventGameOver();
        }
    }

    void OnGameOver()
    {
        EventManager.EventGameOver -= OnGameOver;

        isDriving = false;
        this.transform.parent.transform.position = lastPos;                         //hack to fix the animation "teleport"
        audioSource.Play();
        gameOver = true;
    }

}
