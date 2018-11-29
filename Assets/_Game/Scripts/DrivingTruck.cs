using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrivingTruck : MonoBehaviour {

    Animator animator;

	void Start () {
        animator = GetComponentInChildren<Animator>();
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            animator.SetTrigger("Truck");
        }
    }
}
