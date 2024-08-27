using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] GameObject zombiePreFab;
    [SerializeField] float spawnInterval = 360f; //6 minutes (360 secondes)
    [SerializeField] int numberOfZombiesToSpawn = 20;
    [SerializeField] float timeSinceStart = 0f;
    [SerializeField] Transform[] spawnPoints;
    [SerializeField] bool canStart = false;
    [SerializeField] StartMessage startMessage;
    

    void Start()
    {
        //startMessage = GetComponent<StartMessage>();
        startMessage.OnMessageRead += SetBool;
    }

    void Update()
    {
//<<<<<<< HEAD
       if (canStart)
            ZombieTimer(ref timeSinceStart, spawnInterval);
//=======
        timeSinceStart += Time.deltaTime;
        if (timeSinceStart >= spawnInterval)
        {
            SpawnZombies();
        }
//>>>>>>> Patrick
    }
    void SpawnZombies()
    {
        for (int i = 0; i < numberOfZombiesToSpawn; i++) 
        {
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];
            Instantiate(zombiePreFab, spawnPoint.position, spawnPoint.rotation);
        }
    }
    float ZombieTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            SpawnZombies();
        }
        return _current;
    }
    void SetBool()
    {
        canStart = true;
        Debug.Log(canStart);
    }
}
