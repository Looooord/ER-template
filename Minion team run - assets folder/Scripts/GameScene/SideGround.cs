using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideGround : MonoBehaviour {

    [SerializeField] GameObject pillarPref;
    [SerializeField] GameObject spawnPos; 
    [SerializeField] float spawnDelay = 0.70f;
    float timer;

    private void Awake()
    {
        timer = spawnDelay; 
    }

    private void Update()
    {
        if (timer >= spawnDelay)
        {
            SpawnPillars(); 
            timer = 0; 
        }
        timer += Time.deltaTime; 
    }

    void SpawnPillars ()
    {
        Instantiate(pillarPref, new Vector3(-2.75f, 0.6875f, spawnPos.transform.position.z), Quaternion.identity, transform);
        Instantiate(pillarPref, new Vector3(2.75f, 0.6875f, spawnPos.transform.position.z), Quaternion.identity, transform);
        spawnPos.transform.position += new Vector3(0, 0, 7.5f); 
    }
}
