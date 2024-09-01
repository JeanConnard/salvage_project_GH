using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenUIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI pressAnyKey;
    [SerializeField] TextMeshProUGUI gameName;
    [SerializeField] List<TextMeshProUGUI> textToPrint = new List<TextMeshProUGUI>();
    [SerializeField] TextMeshProUGUI storyText;
    [SerializeField] TextMeshProUGUI storyPage2;
    [SerializeField] TextMeshProUGUI storyPage3;
    [SerializeField] Button quitBTN;
    [SerializeField] GameObject mouseControls;
    TextMeshProUGUI customText;
    [SerializeField] bool canStart = false;
    //[SerializeField] bool canSwitch = false;
    [SerializeField] bool canTimerContinue = true;
    [SerializeField] bool hasBeenPrinted = true;
    [SerializeField] float alphaValue = 0.05f;
    [SerializeField] float currentTime = 0f, customCurrent = 0f;
    [SerializeField] float maxTime = 0.1f, customMax = 3f;
    [SerializeField] string sceneName = "MainScene";
    [SerializeField] int index = 0;
    //[SerializeField] bool indexChanged = false;

 
    void Start()
    {
        Cursor.visible = true;
        quitBTN.onClick.AddListener(QuitGame);
        Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {      
        if(canTimerContinue)
            UpdateAlphaTimer(ref currentTime, maxTime);
        KeyPressed();
        if (canStart)
            UpdateTextAlphaTimer(ref customCurrent, customMax);

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
        if (Input.GetKeyDown(KeyCode.Return))
        {
            pressAnyKey.gameObject.SetActive(false);
            mouseControls.gameObject.SetActive(false);
            quitBTN.gameObject.SetActive(false);
            gameName.gameObject.SetActive(false);
            canTimerContinue = false;
            Cursor.visible = false;
            if (hasBeenPrinted)
            {
                canStart = true;
                textToPrint[0].gameObject.SetActive(true);
                Debug.Log(index);
                hasBeenPrinted = false;
            }
        }
    }
    void OpenScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    void TextBehaviour(TextMeshProUGUI _text)
    {
        customText = _text;
        customText.gameObject.SetActive(true);
        //customText.alpha = 0f;
        //alphaValue = 0.05f;
    }
    void UpdateStoryTextList()
    {
            int _size = textToPrint.Count;
            if(index == _size -1)
            {
                canStart = false;
                OpenScene();
            return;
            }
            index += 1;
            TextBehaviour(textToPrint[index]);
            textToPrint[index -1].gameObject.SetActive(false);
    }
    float UpdateTextAlphaTimer(ref float _customCurrent, float _customMax)
    {
        _customCurrent += Time.deltaTime;
        if (_customCurrent >= _customMax)
        {
            UpdateStoryTextList();
            _customCurrent = 0f;
        }
        return _customCurrent;
    }
    void QuitGame()
    { 
        Application.Quit();
    }
  
        
    
}
