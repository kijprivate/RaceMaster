using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject chunkParent;

    [SerializeField]
    GameObject[] chunkPrefabs;

    [SerializeField]
    Vector3 offset = new Vector3(0f, 0f, 50f);

    private void Start()
    {
        int index = Random.Range(0, chunkPrefabs.Length);
        GameObject chunk = Instantiate(chunkPrefabs[index], Vector3.zero, Quaternion.identity);
        chunk.transform.SetParent(chunkParent.transform);
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Chunk")
        {
            int index = Random.Range(0, chunkPrefabs.Length);
            GameObject chunk = Instantiate(chunkPrefabs[index], other.transform.position+offset, Quaternion.identity);
            chunk.transform.SetParent(chunkParent.transform);
            if (player.transform.position.z > 100f)
            {
                Destroy(chunkParent.transform.GetChild(0).gameObject);
            }
        }
    }
}
