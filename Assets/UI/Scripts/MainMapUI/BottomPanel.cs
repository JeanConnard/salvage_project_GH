using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BottomPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ropeText, fuelText, sandtext, fabricText, woodText, engineText;
    
    //public event Action<int, int, int, int, int, int> OnValueChanged = null; 
    // Start is called before the first frame update
    void Start()
    {
        
       // OnValueChanged += SetCountText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetCountText(int _ropeCount, int _fuelCount, int _sandCount, int _fabricCount, int _woodCount, int _engineCount)
    {
        // Pickup_Item _pickupItemRef = GetComponent<Pickup_Item>();
        Debug.Log("compte de rope" + _ropeCount);
        Debug.Log("compte de fuel" + _fuelCount);
        Debug.Log("compte de sand" + _sandCount);
        Debug.Log("compte de fabric" + _fabricCount);
        Debug.Log("compte de wood" + _woodCount);
        Debug.Log("compte de engine" + _engineCount);

        ropeText.SetText(_ropeCount.ToString());
        fuelText.SetText(_fuelCount.ToString());
        sandtext.SetText(_sandCount.ToString());
        fabricText.SetText(_fabricCount.ToString());
        woodText.SetText(_woodCount.ToString());
        engineText.SetText(_engineCount.ToString());
        Debug.Log(_sandCount);
    }
}
