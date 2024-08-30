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
    [SerializeField] float currentTime = 0f, maxTime = 3f;
    [SerializeField] int textIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        mainPanelRef.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        TextsTimer(ref currentTime, maxTime);
    }

    float TextsTimer(ref float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            _current = 0f;
            TextBehaviour(textList[textIndex]);
        }
        return _current;
    }
    void TextBehaviour(TextMeshProUGUI _text)
    {
        if (textIndex < 0 || textIndex >= textList.Count - 1)
        {
            SceneManager.LoadScene("StartScreenScene");
            return;
        }
        _text.gameObject.SetActive(false);
        textIndex +=1 ;
        textList[textIndex].gameObject.SetActive(true);

    }

}
