using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Plate Prefabs")]
    public GameObject platformPrefab;
    public GameObject winningPlate;

    [Header("Level Attributes")]
    public int numberOfPlatforms;
    public int numberOfPlatformsHigher;
    public float levelWidth = 3f;
    public float minY = .2f;
    public float maxY = 1.5f;
    public float minYHigh = .5f;


    // Start is called before the first frame update
    void Start()
    {
        Vector3 spawnPosition = new Vector3();

        // Spawns the first round of platforms
        for (int i = 0; i < numberOfPlatforms; i++)
        {
            spawnPosition.y += Random.Range(minY, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        // Spawns the next round of platforms at different intervals
        for (int i = 0; i < numberOfPlatformsHigher; i++)
        {
            spawnPosition.y += Random.Range(minYHigh, maxY);
            spawnPosition.x = Random.Range(-levelWidth, levelWidth);
            Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
        }

        // Spawns the Win plate after the 2 rounds.
        spawnPosition.y += minY;
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        Instantiate(winningPlate, spawnPosition, Quaternion.identity);

    }
}
