using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMessage : MonoBehaviour
{
    [SerializeField] float currentTime = 0f, maxTime = 7f;
    [SerializeField] public event Action OnMessageRead = null;
    [SerializeField] StartMessage startMessage;

    void Start()
    {
        gameObject.SetActive(true);

    }

    // Update is called once per frame
    void Update()
    {
        TextTimer(ref currentTime, maxTime);
    }
    float TextTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            gameObject.SetActive(false);
            OnMessageRead?.Invoke();
        }
        return _current;
    }

}
