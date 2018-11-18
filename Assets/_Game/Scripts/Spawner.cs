using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public GameObject[] Vehicles;

    private bool spawned = false;
	// Use this for initialization
	public void Spawn(int spawnerIndex)
    {
        spawned = false;
        if (Vehicles.Length > 0 )
        {
            int randomIndex = Random.Range(0, Vehicles.Length);
            Instantiate(Vehicles[randomIndex], new Vector3 (5f-5f*spawnerIndex,this.transform.position.y,this.transform.position.z), Quaternion.identity);
        }
    }
    private void Start()
    {
       // StartCoroutine(SpawnRoutine());
    }
    private IEnumerator SpawnRoutine()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, Vehicles.Length);
            Instantiate(Vehicles[randomIndex], this.transform.position, Quaternion.identity);
            spawned = true;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
