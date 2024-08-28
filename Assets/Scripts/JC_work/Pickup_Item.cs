using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

[Serializable]
public enum ObjectType
{
    NONE,
    ROPE,
    FUEL,
    FABRIC,
    SAND,
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

    [SerializeField] int ropeCount = 0, fuelCount = 0, fabricCount = 0, sandCount = 0, woodCount = 0, engineCount = 0;

    [SerializeField] ObjectType objectType = ObjectType.NONE;

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
            Debug.Log(ropeCount);
            //Other version to add +1 to 6 differents lists
        }
    }


    void AddToList(int _value)
    {
        if (_value == 0) ropeCount++;
        if (_value == 1) fuelCount++;
        if(_value == 2) fabricCount++;
        if(_value == 3) sandCount++;
        if(_value == 4) woodCount++;
        if(_value == 5) engineCount++;
    }
}
