using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnersHandler : MonoBehaviour {

    public Spawner[] spawners;

    private bool spawned=false;
	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnVehicleRoutine());
	}
	
	private IEnumerator SpawnVehicleRoutine()
    {
        while (true)
        {
            if (spawners.Length > 0)
            {
                int randomIndex = Random.Range(0, spawners.Length);
                spawners[randomIndex].Spawn(randomIndex);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
