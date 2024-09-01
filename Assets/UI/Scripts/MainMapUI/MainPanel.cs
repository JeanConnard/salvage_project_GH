using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    //[SerializeField] HotAirBallon ballonref;
    [SerializeField] Vector3 endPosition;
    [SerializeField] PlayerControler playerRef;
    [SerializeField] float distanceAllowed = 15f;
    [SerializeField] bool ballonReached = false;
    [SerializeField] MusicManager musicManager;
    public event Action OnWin;


    [SerializeField] float distanceBetween;

    void Start()
    {
        endPosition = new Vector3(25, 34, 59);
        OnWin += musicManager.OnWin;
    }

    void Update()
    {
        if (!ballonReached)
            CheckDistance();
    }
    public void CheckDistance()
    {
        Vector3 _ballonPos = endPosition;
        Vector3 _playerPos = playerRef.transform.position;
        distanceBetween = Vector3.Distance(endPosition, playerRef.transform.position);
        if (distanceBetween <= distanceAllowed)
        {
            ballonReached = true;
            WinBehaviour();
            OnWin?.Invoke();
        }
    }
    void WinBehaviour()
    {
        winPanel.SetActive(true);
    }

}
