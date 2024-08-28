
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatWrench : MonoBehaviour
{
    [SerializeField] float direction = 1f;
    [SerializeField] float currentTime = 0f;
    [SerializeField] float maxTime = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        currentTime = IncreaseTime(currentTime, maxTime);
        Move();
    }

    private void Move()
    {
        transform.position += transform.up * Time.deltaTime * direction;
    }
    float IncreaseTime(float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current > maxTime)
        {
            _current = 0;
            SwitchDirection();
        }
        return _current;
    }
    void SwitchDirection()
    {
        direction *= -1;
    }
}
