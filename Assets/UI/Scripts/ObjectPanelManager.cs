using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPanelManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI missingItemTXT = null;
    [SerializeField] Button craftBTN;
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
        craftBTN.onClick.AddListener(CraftHotAirBalloon);
        missingItemTXT.gameObject.SetActive(true);
        //hide les �l�ments du panel
        //afficher message de r�ussite
               
    }
    void CraftHotAirBalloon()
    {
        //instantiate la montgolfi�re (d�finir l'endroit)
    }

}
