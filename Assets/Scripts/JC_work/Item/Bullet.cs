using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float lifeSpan = 5;
    [SerializeField] float moveSpeed = 8;
    [SerializeField] int damage = 1;
    [SerializeField] Vector3 direction = Vector3.zero;

    void Start()
    {
        Destroy(gameObject, lifeSpan);
        Init();
    }

    void Init()
    {
        direction = transform.forward;
    }

    void Update()
    {
        MoveForward();
    }

    void MoveForward()
    {
        transform.position += transform.forward * Time.deltaTime * moveSpeed;
    }

    private void OnTriggerEnter(Collider other) 
    {
        DestructibleElement_Parent _target = other.GetComponent<DestructibleElement_Parent>(); 

        if (!_target) return;
        _target.AddHealth(-damage);
        Debug.Log("Hit");
        Destroy(gameObject);
    }
}
