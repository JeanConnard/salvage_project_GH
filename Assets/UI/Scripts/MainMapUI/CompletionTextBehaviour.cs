using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompletionTextBehaviour : MonoBehaviour
{
    [SerializeField] float currentTime = 0, maxTime = 3;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer();
    }

    void Timer()
    {
        currentTime += Time.deltaTime;
        if(currentTime >= maxTime)
            Disappear();
    }
    void Disappear()
    {
        gameObject.SetActive(false);
    }
}
