using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBehaviour : DestructibleElement_Parent
{

    void Start()
    {
        health = 3;

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

        Instantiate(wood, _spawnPosition, transform.rotation);
        Instantiate(wood, _spawnPosition, transform.rotation);
        Instantiate(wood, _spawnPosition, transform.rotation);        
    }
}
