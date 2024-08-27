using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;

public class CarBehaviour : DestructibleElement_Parent
{
    // Start is called before the first frame update
    void Start()
    {
        health = 2;

        OnDestruction += Destruction;
    }

    void Update()
    {
        
    }

    void Destruction()
    {
        Instantiate(rope,transform.position, Quaternion.identity);
        Instantiate(rope,transform.position, Quaternion.identity);
        Instantiate(rope,transform.position, Quaternion.identity);

        gameObject.SetActive(false);
        //Destroy(gameObject);
        
    }
}
