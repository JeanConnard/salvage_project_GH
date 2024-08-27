using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePreFab;
    [SerializeField] private float spawnInterval = 360f; //6 minutes (360 secondes)
    [SerializeField] private int numberOfZombiesToSpawn = 20;
    private float timeSinceStart = 0f; //time elaspe from start game
    [SerializeField] private Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart >= spawnInterval)
        {
            SpawnZombies();
        }
    }
    private void SpawnZombies()
    {
        for (int i = 0; i < numberOfZombiesToSpawn; i++) 
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            Instantiate(zombiePreFab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
