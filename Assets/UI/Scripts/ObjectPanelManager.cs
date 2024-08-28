using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI missingItemTXT = null;
    [SerializeField] Button craftBTN;
    [SerializeField] public bool ropeComplete = false,
                          fuelComplete = false,
                          sandComplete = false,
                          fabricComplete = false,
                          woodComplete = false,
                          engineComplete = false;
    public Action<int> OnTest = null;
    void Start()
    {
        //Invoke("Init", 1);
        Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Init()
    {
        //craftBTN = GetComponent<Button>();
        craftBTN.onClick.AddListener(CraftHotAirBalloon);
        missingItemTXT.gameObject.SetActive(true);
        //hide les éléments du panel
        //afficher message de réussite
        OnTest(2);

    }
    void CraftHotAirBalloon()
    {
        //instantiate la montgolfière (définir l'endroit)

    }
    public void UpdateBoolResult(bool _result)
    {
        _result = true;
        Debug.Log("resultat de fuelcomplete: " + fuelComplete);
        Debug.Log("resultat de _result: " + _result);
        TestResult();
        //return true; 
    }
    public void SetVisibility()
    {
        Debug.Log("Bools are ok");
    }
    void TestResult()
    {

    }

}
