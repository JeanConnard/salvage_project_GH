using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelManager : MonoBehaviour
{
    [SerializeField] GameObject mainPanel;
    [SerializeField] TextMeshProUGUI deathText;
    [SerializeField] bool isDead = false;
    [SerializeField] float startTime = 0f, maxTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead)
            startTime = DeathTimer(startTime, maxTime);
    }
    public void OnDeathBool()
    {
        Debug.Log("hoooo");
        isDead = true;
    }
    float DeathTimer(float _current, float _max)
    {
        deathText.gameObject.SetActive(true);
        mainPanel.SetActive(false);
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
