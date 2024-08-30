using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestBoucles : MonoBehaviour
{
    [SerializeField] float currentTime = 0f, maxTime = 1f;
    [SerializeField] List<int> ints = new List<int>();
    [SerializeField] int index = 0;
    bool canStart = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TimerTest(ref currentTime, maxTime);
    }
    float TimerTest(ref float _current, float _max)
    {
            _current += Time.deltaTime;
            int _size = ints.Count;
            for (index = 0; index < _size; index++ )
            {
            if (canStart)
            {
                canStart = false;
                if (_current >= _max)
                {
                    Debug.Log(ints[index]);
                    canStart = true;
                }
            }
                    _current = 0f;                    
            }
        return _current;
    }
}
