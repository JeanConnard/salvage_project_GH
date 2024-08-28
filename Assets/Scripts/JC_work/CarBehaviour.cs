using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBehaviour : DestructibleElement_Parent
{

    void Start()
    {
        health = 5;

        OnDestruction += Explosion;
    }

    void Update()
    {
        
    }

    void Explosion()
    {
        gameObject.SetActive(false);
        
        float _random = Random.Range(-0.1f, 0.1f);
        Vector3 _spawnPosition = transform.position + transform.forward * _random + transform.up * 1;
        
        Instantiate(fuel, _spawnPosition, transform.rotation);
        Instantiate(fuel, _spawnPosition, transform.rotation);
        Instantiate(enginePart, _spawnPosition, transform.rotation);
        Instantiate(rope, _spawnPosition, transform.rotation);
        Instantiate(trash, _spawnPosition, transform.rotation);
        Instantiate(trash, _spawnPosition, transform.rotation);
        Instantiate(trash, _spawnPosition, transform.rotation);
    }
}
