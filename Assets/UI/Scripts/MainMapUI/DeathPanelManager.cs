using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelManager : MonoBehaviour
{
    //[SerializeField] GameObject mainPanel;
    [SerializeField] GameObject deathPanel;
    [SerializeField] bool isDead = false;
    [SerializeField] float startTime = 0f, maxTime = 4f;

    void Start()
    {
        
    }

    void Update()
    {
        if (isDead)
        {
            DeathTimer(ref startTime, maxTime);

        }
    }

    public void OnDeathBool(bool _value)
    {
        isDead = _value;
        deathPanel.SetActive(true);
    }
    float DeathTimer(ref float _current, float _max)
    {
        if (!isDead) return 0;
     
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            OpenStartScene();
        }
        return _current;
    }
    void OpenStartScene()
    {
        SceneManager.LoadScene("StartScreenScene");
    }
}
