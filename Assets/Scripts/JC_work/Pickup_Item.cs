using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.InputSystem;

/*  //I didn't use it
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
}*/

//Script a placer sur le player

public class Pickup_Item : MonoBehaviour
{
    public event Action<LayerMask> OnObjectGarb = null;

    [SerializeField] Controls controls = null;
    [SerializeField] InputAction rightClick = null;

    [SerializeField] bool canGrab = false;

    [SerializeField] GameObject itemToInteract;
   
    //Others variables I didn't use
    //[SerializeField] int robeCollects = 0;
    //[SerializeField] int fuelCollects = 0;
    //[SerializeField] ObjectType objectType = ObjectType.NONE;

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
            OnObjectGarb?.Invoke(itemToInteract.layer); //for the UI subcription
            
            //Other version to add +1 to 6 differents lists
            //AddToList(itemToInteract.layer - 7);
        }
    }

    /*
    void AddToList(int _value)
    {
        if(_value == 0) robeCollects++;
        if(_value == 1) fuelCollects++;
        //if(_value == 2) fabricCollects++;
        //if(_value == 3) sandCollects++;
        //if(_value == 4) woodCollects++;
        //if(_value == 5) enginePartCollects++;
    }*/
}
