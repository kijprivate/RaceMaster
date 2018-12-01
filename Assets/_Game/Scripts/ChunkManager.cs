using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkManager : MonoBehaviour {

    [SerializeField]
    GameObject player;

    [SerializeField]
    GameObject chunkParent;

    [SerializeField]
    GameObject[] chunkDesertPrefabs;

    [SerializeField]
    GameObject[] chunkGreenPrefabs;

    [SerializeField]
    GameObject[] chunkWinterPrefabs;

    [SerializeField]
    GameObject[] chunkPrefabs;

    [SerializeField]
    Vector3 offset = new Vector3(0f, 0f, 50f);

    int lastIndex;
    int index;

    private void Awake()
    {
        int setOfChunks = PlayerPrefsManager.GetChoosenEnvNumber();

        switch(setOfChunks)
        {
            case 0:
                chunkPrefabs = chunkDesertPrefabs;
                break;
            case 1:
                chunkPrefabs = chunkGreenPrefabs;
                break;
            case 2:
                chunkPrefabs = chunkWinterPrefabs;
                break;
            default:
                chunkPrefabs = chunkDesertPrefabs;
                Debug.LogWarning("Unexpected set of chunks");
                break;
        }
    }

    private void Start()
    {
        int index = Random.Range(0, chunkPrefabs.Length);
        chunkPrefabs[index].transform.position = Vector3.zero;
        chunkPrefabs[index].SetActive(true);
        lastIndex = index;
    }
    // Use this for initialization
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Chunk")
        {
            while (index == lastIndex)
            {
                index = Random.Range(0, chunkPrefabs.Length);
            }
            chunkPrefabs[index].transform.position = other.transform.position + offset;
            chunkPrefabs[index].SetActive(true);

            if (player.transform.position.z > 100f)
            {
                foreach(var chunk in chunkPrefabs)
                {
                   // chunk.SetActive(false);
                }
                chunkPrefabs[lastIndex].SetActive(true);
                chunkPrefabs[index].SetActive(true);
            }
            lastIndex = index;
        }
    }
}
