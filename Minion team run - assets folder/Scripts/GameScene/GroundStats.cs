using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundStats : MonoBehaviour {

    public float moveSpeed = 10f;
    [SerializeField] Transform spawnPos;
    [SerializeField] GameObject chunk1Prefab;
    [SerializeField] GameObject chunk2Prefab;
    bool chunkType = false; 

    static bool obstacle = false; 
    static bool missingBl = false;
    int blockNum = -1; 
    static bool rottenTree = false;
    [SerializeField] GameObject rottenTreePref;
    static bool fallenPillar = false;
    [SerializeField] GameObject fallenPillarPref;


    [SerializeField] GameObject coinPref;

    private void Awake()
    {
        InstantiateNewChunk();
        InstantiateNewChunk(); 
    }
    public void InstantiateNewChunk()
    {
        GameObject chunk;
        if (chunkType)
        chunk = Instantiate(chunk1Prefab, spawnPos.position, Quaternion.identity, transform);
        else chunk = Instantiate(chunk2Prefab, spawnPos.position, Quaternion.identity, transform);
        chunkType = !chunkType; 
        if (obstacle)
        {
            if (missingBl)
            {
                int num = Random.Range(0, 3);
                if (blockNum == -1)
                {
                    blockNum = num; 
                }
                else
                {
                    num = blockNum;
                    blockNum = -1; 
                    missingBl = false;
                    obstacle = false;
                }
                chunk.transform.GetChild(num).gameObject.SetActive(false);
                
            }
            else if (rottenTree)
            {
                Instantiate(rottenTreePref, chunk.transform.position, Quaternion.identity, chunk.transform);
                rottenTree = false;
                obstacle = false;
            }
            else if (fallenPillar)
            {
                int num = Random.Range(0, 3);
                Transform tile = chunk.transform.GetChild(num);
                Instantiate(fallenPillarPref, tile.position, Quaternion.identity, tile);
                fallenPillar = false;
                obstacle = false;
            }
            
        }
        else if (CoinSpawnBool())
        {
            int num = Random.Range(0, 3);
            Transform tile = chunk.transform.GetChild(num).transform;
            Instantiate(coinPref, tile.transform.position, Quaternion.identity, tile.transform); 
        }
        spawnPos.position = new Vector3(0, 0, spawnPos.position.z + 1.5f); 
    }

    public static void MissingBlock()
    {
        obstacle = true; 
        missingBl = true; 
    }

    public static void RottenTree()
    {
        obstacle = true;
        rottenTree = true; 
    }

    public static void FallenPillar()
    {
        obstacle = true;
        fallenPillar = true; 
    }

    bool CoinSpawnBool()
    {
        if (Random.Range(0, 11) == 1) return true;
        else return false; 
    }
}
