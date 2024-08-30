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
            DeathTimer(ref startTime, maxTime);
    }
    public void OnDeathBool(bool _value)
    {
        isDead = _value;
        deathText.gameObject.SetActive(true);
        mainPanel.SetActive(false);

    }
    float DeathTimer(ref float _current, float _max)
    {
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
