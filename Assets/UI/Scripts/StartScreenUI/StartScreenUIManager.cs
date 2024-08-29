using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pressAnyKey;
    [SerializeField] List<TextMeshProUGUI> textToPrint = new List<TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI storyText;
    [SerializeField] TextMeshProUGUI storyPage2;
    [SerializeField] TextMeshProUGUI storyPage3;
    TextMeshProUGUI customText;
    [SerializeField] bool canStart = false;
    [SerializeField] float alphaValue = 0.05f;
    [SerializeField] float currentTime = 0f;
    [SerializeField] float maxTime = 0.1f;
    [SerializeField] string sceneName = "NewScene";

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAlphaTimer(ref currentTime, maxTime);
        KeyPressed();
        if (canStart)
            UpdateTextAlphaTimer(currentTime, maxTime);

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
    }
    void ReverseValue()
    {
        alphaValue *= -1f;
    }
    void KeyPressed()
    {
        if (Input.anyKeyDown)
        {
            pressAnyKey.gameObject.SetActive(false);
            canStart = true;
            storyText.gameObject.SetActive(true);            
            TextBehaviour(storyText);
        }
    }
    void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    void TextBehaviour(TextMeshProUGUI _text)
    {
        customText = _text;
        //UpdateStoryTextList();
    }
    void UpdateStoryTextList()
    {
        int _size = textToPrint.Count;
        for (int i = 0; i < _size; i++)
        {
            Debug.Log(i);
            
            textToPrint[i].alpha = 0f;
            if (textToPrint[i].alpha >= 1f)
            {
                ReverseValue();
            }
            textToPrint[i].alpha += alphaValue;
            if (textToPrint[i].alpha < 0f)
            {
                return;
            }
            TextBehaviour(textToPrint[i]);
            //if (textToPrint[_size + 1] && textToPrint[_size +1].alpha < 0f)
            //    OpenScene();
        }
    }
    float UpdateTextAlphaTimer(float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            _current = 0f;
            UpdateStoryTextList();
        }
        return _current;
    }
}
