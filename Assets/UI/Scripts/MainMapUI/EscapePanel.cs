using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EscapePanel : MonoBehaviour
{
    [SerializeField] Button quitBTN = null;
    [SerializeField] Button resumeBTN = null;

    void Start()
    {
        Init();
        Cursor.visible = true;
       
        quitBTN.onClick.AddListener(QuitGame);
        resumeBTN.onClick.AddListener(ResumeGame);        
    }

    void Update()
    {
        //Cursor.lockState = CursorLockMode.None;
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
        //Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
