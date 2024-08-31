using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanel : MonoBehaviour
{
    [SerializeField] GameObject winPanel;
    [SerializeField] HotAirBallon ballonref;
    [SerializeField] PlayerControler playerRef;
    [SerializeField] float distanceAllowed = 50f;
    [SerializeField] bool ballonReached = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!ballonReached)
            CheckDistance();
    }
    void CheckDistance()
    {
        Vector3 _ballonPos = ballonref.transform.position;
        Vector3 _playerPos = playerRef.transform.position;
        if ((Vector3.Distance(_ballonPos, _playerPos) <= distanceAllowed))
        {
            ballonReached = true;
            WinBehaviour();
        }
    }
    void WinBehaviour()
    {
        winPanel.SetActive(true);
    }

}
