using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pressAnyKey;
    [SerializeField] float alphaValue = 0.05f;    
    [SerializeField] float currentTime = 0f;
    [SerializeField] float maxTime = 0.1f;
    [SerializeField] string sceneName = "MainScene";    

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAlphaTimer(ref currentTime, maxTime);
        KeyPressed();
    }
    float UpdateAlphaTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            UpdateAlphaValue();
            _current = 0;
        }
        return _current;
    }
    void UpdateAlphaValue()
    {
        if (pressAnyKey.alpha >= 1f || pressAnyKey.alpha < 0f)
        {
            ReverseValue();
        }
        pressAnyKey.alpha += alphaValue;
        Debug.Log(pressAnyKey.alpha.ToString());
    }
    void ReverseValue()
    {
        alphaValue *= -1f;
    }
    void KeyPressed()
    {
        if(Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneName);            
        }
    }
}
