using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winTXT;
    [SerializeField] TextMeshProUGUI creditsTXT;
    [SerializeField] TextMeshProUGUI thanksTXT;
    [SerializeField] TextMeshProUGUI trollTXT;
    [SerializeField] List<TextMeshProUGUI> textList = new List<TextMeshProUGUI>();
    [SerializeField] GameObject mainPanelRef;
    [SerializeField] float currentTime = 0f, maxTime = 6f;
    [SerializeField] int textIndex = 0;
    [SerializeField] bool canStart = true;
    

    // Start is called before the first frame update
    void Start()
    {
        mainPanelRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        currentTime = TextsTimer(currentTime, maxTime);
    }

    float TextsTimer(float _current, float _max)
    {        _current += Time.deltaTime;
        if (canStart)
        {

            if (_current >= _max)
            {
                canStart = false;
                TextBehaviour();
                _current = 0f;
            }
        }
        return _current;
    }
    void TextBehaviour()
    {
        Debug.Log(textList[textIndex]);
        if (textIndex < 0 || textIndex >= textList.Count - 1)
        {
            SceneManager.LoadScene("StartScreenScene");
            return;
        }
        textList[textIndex].gameObject.SetActive(false);
        textIndex +=1 ;
        CanStartTimer();
    }
    void CanStartTimer()
    {
        textList[textIndex].gameObject.SetActive(true);
        canStart = true;
        currentTime = 0f;
    }

}
