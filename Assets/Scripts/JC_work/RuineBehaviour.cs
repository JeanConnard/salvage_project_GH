using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuineBehaviour : DestructibleElement_Parent
{

    public override void Start()
    {
        health = 7;

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

        Instantiate(sand, _spawnPosition, transform.rotation);
        Instantiate(sand, _spawnPosition, transform.rotation);
        Instantiate(sand, _spawnPosition, transform.rotation);
        Instantiate(sand, _spawnPosition, transform.rotation);
        Instantiate(rope, _spawnPosition, transform.rotation);
        Instantiate(trash, _spawnPosition, transform.rotation);
        Instantiate(trash, _spawnPosition, transform.rotation);
        Instantiate(trash, _spawnPosition, transform.rotation);
        Instantiate(trash, _spawnPosition, transform.rotation);
    }
}
