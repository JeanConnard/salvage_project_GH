using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Pickup_Item : MonoBehaviour
{
    //public event Action<RaycastHit> OnHit = null;
    Action<Transform> OnTargetDetected = null;
 
    [SerializeField] float detectionRange = 20;
    [SerializeField] LayerMask itemLayer = 0;
    [SerializeField] Transform objectSelected = null;
    [SerializeField] bool canSelect = true;

    //[SerializeField] Controls controls = null;
    //[SerializeField] InputAction rightClick = null;

    Ray screenRay = new Ray();
    bool detected = false;

    //public InputAction RightClick => rightClick;

    private void Awake()
    {
        //controls = new Controls();
    }

    private void OnEnable()
    {
        //rightClick = controls.AM.Select;
        //rightClick.Enable();
        //rightClick.performed += Detect;
    }

    void Start()
    {

    }


    void Update()
    {
        Detect();
    }

    void Detect()
    {
        bool _hit = Physics.Raycast(transform.position, transform.forward, out RaycastHit _hitRay, detectionRange, itemLayer);
        Debug.DrawRay(transform.position, transform.forward * detectionRange, _hit ? Color.green : Color.red);
        if (_hit)
        {
            objectSelected = _hitRay.transform;
            Debug.Log("Cliquez pour sélectionner");
            //OnTargetDetected?.Invoke(_hitRay.transform);
        }
    }
}
