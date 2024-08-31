using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI missingItemTXT = null;
    [SerializeField] Button craftBTN;
    //[SerializeField] bool ropeComplete = false,
    //                      fuelComplete = false,
    //                      sandComplete = false,
    //                      fabricComplete = false,
    //                      woodComplete = false,
    //                      engineComplete = false;
    [SerializeField] bool listCompleted = false;
    [SerializeField] GameObject requirementPanel;
    [SerializeField] GameObject listPanel;
    [SerializeField] TextMeshProUGUI completionText;
    [SerializeField] GameObject hotAirBallon;
    [SerializeField] Vector3 spawnPosition = new Vector3(25f, 9.35f, 31.22f);
    [SerializeField] Quaternion spawnRotation = new Quaternion(-90f, 0f, 0f, 0f);
    void Start()
    {        
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Init()
    {
        //craftBTN = GetComponent<Button>();
        //missingItemTXT.gameObject.SetActive(true);
        //craftBTN.onClick.AddListener(CraftHotAirBalloon);
        craftBTN.onClick.AddListener(SetVisibility);
        craftBTN.onClick.AddListener(OnCompletion);

        //hide les éléments du panel
        //afficher message de réussite     
    }
    void CraftHotAirBalloon()
    {               
        Instantiate(hotAirBallon, spawnPosition, spawnRotation);
    
    }
    public void UpdateBoolResult(bool _result)
    {
        _result = true;              
        //return true; 
    }
    public void SetCompleted(bool _value)
    {   
        listCompleted = _value;
        SetVisibility();        
    }
    void SetVisibility()
    {
        if (listCompleted)
        {
            missingItemTXT.gameObject.SetActive(false);
            craftBTN.gameObject.SetActive(true);            
        }
    }
    void OnCompletion()
    { 
        requirementPanel.SetActive(false);
        listPanel.SetActive(false);
        craftBTN.gameObject.SetActive(false);
        completionText.gameObject.SetActive(true);
        CraftHotAirBalloon();
    }

}
