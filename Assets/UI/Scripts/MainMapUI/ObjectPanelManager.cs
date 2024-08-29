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

        //hide les �l�ments du panel
        //afficher message de r�ussite     
    }
    void CraftHotAirBalloon()
    {
        Instantiate(hotAirBallon);
        //instantiate la montgolfi�re (d�finir l'endroit)
    }
    public void UpdateBoolResult(bool _result)
    {
        _result = true;
        //Debug.Log("resultat de fuelcomplete: " + fuelComplete);
        Debug.Log("resultat de _result: " + _result);        
        //return true; 
    }
    public void SetCompleted(bool _value)
    {   
        listCompleted = _value;
        SetVisibility();
        Debug.Log("Show button ");
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
