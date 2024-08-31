using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    //Timer
    [SerializeField] StartMessage startMessage;
    [SerializeField] bool canStart = false;

    [SerializeField] List<GameObject> zombies = new List<GameObject>();
    [SerializeField] float timerTotal = 360f; //6 minutes (360 secondes)
    [SerializeField] float currentTime = 0;
    //[SerializeField] public event Action OnTimerEnd = null;


    void Start()
    {
        //zombies = GetComponent<ZombieAI>();
        startMessage.OnMessageRead += SetBool;
    }

    void Update()
    {
        if (!canStart) return;
           
        currentTime += Time.deltaTime;
        if (currentTime >= timerTotal)
        {
            //OnTimerEnd?.Invoke();
            //ZombieAI.
            int _size = zombies.Count;
            for (int i = 0; i < _size; i++)
            {
                zombies[i].SetActive(true);
            }
        }
    }

    void SetBool()
    {
        canStart = true;
        Debug.Log(canStart);
    }
   
}
