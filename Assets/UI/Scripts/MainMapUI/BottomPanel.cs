using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BottomPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ropeText, fuelText, sandtext, fabricText, woodText, engineText;
   
    [SerializeField] Color inachievedColor = Color.black;
    [SerializeField] Color achievedColor = Color.green;


    //public event Action<int, int, int, int, int, int> OnValueChanged = null; 
    // Start is called before the first frame update
    void Start()
    {
        ropeText.color = inachievedColor;
        fuelText.color = inachievedColor;
        sandtext.color = inachievedColor;
        fabricText.color = inachievedColor;
        woodText.color = inachievedColor;
        engineText.color = inachievedColor;
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
        if (_ropeCount >= 5) ropeText.color = achievedColor;
        fuelText.SetText(_fuelCount.ToString());
        if (_fuelCount >= 3) fuelText.color = achievedColor;
        sandtext.SetText(_sandCount.ToString());
        if (_sandCount >= 5) sandtext.color = achievedColor;
        fabricText.SetText(_fabricCount.ToString());
        if (_fabricCount >= 20) fabricText.color = achievedColor;
        woodText.SetText(_woodCount.ToString());
        if (_woodCount >= 10) woodText.color = achievedColor;
        engineText.SetText(_engineCount.ToString());
        if (_engineCount >= 1) engineText.color = achievedColor;

        //Debug.Log(_sandCount);
    }

    public void ColorText(bool _ropeBool, bool _fuelBool, bool _sandBool, bool _fabricBool, bool _woodBool, bool _engineBool)
    {
        Debug.Log("allo");
        if(_ropeBool) ropeText.color = achievedColor;
        if(_fuelBool) fuelText.color = achievedColor;
        if(_sandBool) sandtext.color = achievedColor;
        if(_fabricBool) fabricText.color = achievedColor;
        if(_woodBool) woodText.color = achievedColor;
        if(_engineBool) engineText.color = achievedColor;
    }
}
