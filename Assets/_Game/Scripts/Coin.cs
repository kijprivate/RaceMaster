using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    AudioClip clip;

    ParticleSystem particleSystem;
    Animator animator;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
        animator = GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)   // todo handle everything in eventcoincollected
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
            particleSystem.Play();
            EventManager.RaiseEventCoinCollected();
            animator.SetTrigger("Collected");
            StartCoroutine(DestroyRoutine());
        }
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.4f);
        Destroy(this.gameObject);
    }
}
