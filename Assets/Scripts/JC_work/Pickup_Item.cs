using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public enum ObjectType
{
    NONE,
    ROPE,
    FUEL,
    SAND,
    FABRIC,
    WOOD,
    ENGINE_PIECE
}

//Script a placer sur le player

public class Pickup_Item : MonoBehaviour
{
    public event Action<LayerMask> OnObjectGrab = null;

    [SerializeField] Controls controls = null;
    [SerializeField] InputAction rightClick = null;

    [SerializeField] bool canGrab = false;

    [SerializeField] GameObject itemToInteract;
    
    [SerializeField] ObjectType objectType = ObjectType.NONE;
    
    [SerializeField] BottomPanel panelRef;
    [SerializeField] int ropeCount = 0, fuelCount = 0, sandCount = 0, fabricCount = 0, woodCount = 0, engineCount = 0;
    [SerializeField] bool ropeComplete = false, fuelComplete = false, sandComplete = false, 
                         fabricComplete = false, woodComplete = false, engineComplete = false;
    
    public Action<int, int, int, int, int, int> OnValueChanged = null;      //changes UI BottomPanel int
    public Action<bool, bool, bool, bool, bool, bool> OnBoolChange = null;  //changes UI BottomPanel bool
    public Action<bool> OnTargetAquired = null;
    public Action<bool> OnCompletion = null;

    [SerializeField] ObjectPanelManager objectPanelRef;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        rightClick = controls.AM.grab;
        rightClick.Enable();

        rightClick.performed += PickUp;
    }
    void Start()
    {
        OnValueChanged += panelRef.SetCountText;
        //OnBoolChanged += objectPanelRef.UpdateBoolResult;
        OnCompletion += objectPanelRef.SetCompleted;
    }

    void Update()
    {
        
    }
    public void GrabPossibility(bool _value)    //to know if the raycast targets an object
    {
        canGrab = _value;        
    }

    public void ObjectDefine(RaycastHit _hitItem)   //to know what kind of object is targeted
    {
        itemToInteract = _hitItem.transform.gameObject;
    }

    void PickUp(InputAction.CallbackContext _context)   //click to pickup
    {
        if (canGrab)
        {
            Destroy(itemToInteract);
            OnObjectGrab?.Invoke(itemToInteract.layer); //for the UI subcription
            AddToList(itemToInteract.layer - 7);              
        }
    }


    void AddToList(int _value)
    {
        if (_value == 0) ropeCount++;
        if (_value == 1) fuelCount++;
        if(_value == 2) sandCount++;
        if(_value == 3) fabricCount++;
        if(_value == 4) woodCount++;
        if(_value == 5) engineCount++;

        CheckCompletion();
        OnValueChanged.Invoke(ropeCount, fuelCount, sandCount, fabricCount, woodCount, engineCount);
        //if (fuelCount >= 2)
        //    OnBoolChange?.Invoke(ropeComplete, fuelComplete, sandComplete, fabricComplete, woodComplete, engineComplete);
        //OnBoolChanged?.Invoke(objectPanelRef.fuelComplete);
        //    panelRef.UpdateBoolResult(panelRef.fuelComplete);

    }
    void CheckCompletion()
    {
        ropeComplete = ropeCount >= 1;
        fuelComplete = fuelCount >= 1;
        sandComplete = sandCount >= 1;
        fabricComplete = fabricCount >= 1;
        woodComplete = woodCount >= 1;
        engineComplete = engineCount >= 1;
        if (ropeComplete && fuelComplete && sandComplete && fabricComplete && woodComplete && engineComplete)
            OnCompletion?.Invoke(true);
            
    }
}
