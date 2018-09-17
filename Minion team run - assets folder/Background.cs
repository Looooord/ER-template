using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour {

    public static float moveSpeed = 14f;
    float spawnDelay = 11;
    float timer;

    [SerializeField] GameObject terrainPref;
    [SerializeField] GameObject spawnPos; 

    private void Awake()
    {
        timer = spawnDelay;
    }

    private void Update()
    {
        if (timer >= spawnDelay)
        {
            SpawnTerrain();
            timer = 0; 
        }
        timer += Time.deltaTime;
    }

    void SpawnTerrain()
    {
        Instantiate(terrainPref, spawnPos.transform.position, Quaternion.identity, transform);
        spawnPos.transform.position += new Vector3(0,0,152);  
    }
}
