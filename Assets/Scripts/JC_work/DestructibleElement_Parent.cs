using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleElement_Parent : MonoBehaviour
{
    public event Action OnDestruction = null;
    [SerializeField] protected int health = 0;
    [SerializeField] protected GameObject rope = null; 

    void Start()
    {
        rope = GetComponent<GameObject>();
    }

    void Update()
    {
       // Destroy();
       
    }

    //void Destroy()
    //{
    //    if (health <= 0)
    //    {
    //        Debug.Log("mort");
    //        OnDestruction?.Invoke();
    //    }
    //}
    public void AddHealth(int _value)
    {
        health += _value;
        //health = health <= 0 ? 0 : health >= 5 ? 5 : health;
        if (health == 0)
        {
            OnDestruction?.Invoke();
        }
    }

}
