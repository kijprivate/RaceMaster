using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    [SerializeField]
    AudioClip clip;

    ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem = GetComponent<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(clip, this.transform.position);
            particleSystem.Play();
            StartCoroutine(DestroyRoutine());
        }
    }

    private IEnumerator DestroyRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(this.gameObject);
    }
}
