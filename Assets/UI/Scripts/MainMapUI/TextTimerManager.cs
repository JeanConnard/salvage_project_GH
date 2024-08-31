using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTimerManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hourText;
    [SerializeField] TextMeshProUGUI minuteText;
    [SerializeField] int hours = 6;
    [SerializeField] int minutes = 0;
    [SerializeField] StartMessage startMessage;
    [SerializeField] bool canStartCountDown = false;
    [SerializeField] float currentTime = 0f, maxTime = 1f;
    [SerializeField] event Action<int, int> OnTimeElapsed = null;

    void Start()
    {        
        hourText.SetText(hours.ToString());
        startMessage.OnMessageRead += SetBool;
        OnTimeElapsed += SetTimerText;
    }

    void Update()
    {
        if (canStartCountDown)
            CountDown(ref currentTime, maxTime);
    }
    void SetBool()
    {
        canStartCountDown = true;
    }
    float CountDown(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if(_current >= _max)
        {
            _current = 0;
            if (minutes <= 0)
            {
                minutes = 60;
                hours -= 1;
            }
            minutes -= 1;
            OnTimeElapsed?.Invoke(hours, minutes);
            if (hours <= 0 && minutes <= 0)
                canStartCountDown = false;
        }
       
        return _current;
    }
    void SetTimerText(int _hours, int _minutes)
    {
        hourText.SetText(hours.ToString());
        minuteText.SetText(minutes.ToString());
    }
}
