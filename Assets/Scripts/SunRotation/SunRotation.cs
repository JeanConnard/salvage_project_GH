using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{
    [SerializeField] float rotationValue = 0.09f;
    [SerializeField] float currentTime = 0f, maxTime = 0.5f;
    [SerializeField] bool isStillDay = true;
    [SerializeField] int rotationIndex = 0;

    void Start()
    {  
    }

    // Update is called once per frame
    void Update()
    {
        if (isStillDay)
            SunTimer(ref currentTime, maxTime);
    }
    void Rotation()
    {
        transform.eulerAngles -= transform.right * rotationValue;
    }
    //créer une valeur int à additionner chaque fois
    //et si la valeur est atteinte alors bool false
    float SunTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            _current = 0f;
            rotationIndex++;
            Rotation();
            //Debug.Log(rotationIndex);
            if (rotationIndex >= 715)
                isStillDay = false;
        }

        return _current;
    }
}
