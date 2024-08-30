using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapePanel : MonoBehaviour
{
    [SerializeField] Button quitBTN = null;
    [SerializeField] Button resumeBTN = null;
    // Start is called before the first frame update
    void Start()
    {
        Init();
        Cursor.visible = true;
        quitBTN.onClick.AddListener(QuitGame);
        resumeBTN.onClick.AddListener(ResumeGame);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
    }
    void Init()
    {
        
    }
    public void ResumeGame()
    {        
        Time.timeScale = 1;
        gameObject.SetActive(false);
        Cursor.visible = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
