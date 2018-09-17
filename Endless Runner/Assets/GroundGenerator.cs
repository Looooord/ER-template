using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGenerator : MonoBehaviour {

    public static GroundGenerator instance;

    Ground gr;
    Transform spawnPosTransform;
    [SerializeField] GameObject chunkPref;
    [SerializeField] float chunkLength;
    Transform prevChunk; 

    private void Awake()
    {
        if (instance == null) instance = this;
        else this.enabled = false; 

        gr = GetComponent<Ground>();
        spawnPosTransform = transform.Find("SpawnPos");

        prevChunk = Instantiate(chunkPref, Vector3.zero, Quaternion.identity, transform).transform;
        for (int i = 0; i < gr.chunksInScene -1; i++)
        {
            GenerateNewChunk(); 
        }
    }

    public void GenerateNewChunk()
    {
        Vector3 spawnPos = spawnPosTransform.position; 
        prevChunk = Instantiate(chunkPref, spawnPos, Quaternion.identity, transform).transform; //instantiate new chunk at the position of the gameobject "spawnPos"
        spawnPosTransform.position += new Vector3(0, 0, chunkLength); //moved the spawnpos obj in the position where the next chunk is gonna be instantiated

    }
}
