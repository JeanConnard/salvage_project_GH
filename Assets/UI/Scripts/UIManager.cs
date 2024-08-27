using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject startMessagePanel = null;
    //[SerializeField] public TextMeshPro startMessage = null;
    //[SerializeField] TextMeshPro hourTimerText = null;
    //[SerializeField] TextMeshPro minutesTimerText = null;
    [SerializeField] float currentTime = 0f, maxTime = 5.0f;

    void Start()
    {
        startMessagePanel= GetComponent<GameObject>() ;
        startMessagePanel.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        TextTimer(ref currentTime, maxTime);
    }
    float TextTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current > maxTime)
        {
            startMessagePanel.gameObject.SetActive(false);
            //lancer timer zombie (bool true)

        }
        return _current;
    }

}
