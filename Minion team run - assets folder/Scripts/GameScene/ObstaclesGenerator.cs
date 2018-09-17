
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesGenerator : MonoBehaviour
{
    [SerializeField] float spawnDelay = 5f; 
    float timer = 0;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            GenerateObstacle();
            timer = 0; 
        }
    }

    void GenerateObstacle()
    {
        int type = ChooseObstacleToSpawn(); 
        switch (type) {
            case 0:
                Debug.Log("missing block");
                GroundStats.MissingBlock();
                break;

            case 1:
                Debug.Log("rotten tree");
                GroundStats.RottenTree(); 
                break;

            case 2:
                Debug.Log("fallen pillar");
                GroundStats.FallenPillar(); 
                break; 
            }
    }

    int ChooseObstacleToSpawn()
    {
        float number = Random.Range(0, 100); 
        if (number < 100/3)
        {
            return 0; 
        }
        else if (number > 66)
        {
            return 1; 
        }
        else
        {
            return 2; 
        }
    }
}