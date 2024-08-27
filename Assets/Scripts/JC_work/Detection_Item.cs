using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.InputSystem;

//Script a placer sur la caméra, elle même Child du Player

public class Detection_Item : MonoBehaviour
{
    public event Action<RaycastHit> OnTargetDetected = null;
    public event Action<bool> OnHit = null;

    //for the verticale cam rotation
    //[SerializeField] Controls controls = null;
    //[SerializeField] InputAction lookInput = null;
    //[SerializeField] int rotationSpeed = 200;

    [SerializeField] float detectionRange = 20;
    [SerializeField] LayerMask itemLayer = 0;   //in Unity, put all 6 layers manually
    [SerializeField] Transform objectSelected = null;
    [SerializeField] bool canSelect = true;

    [SerializeField] Pickup_Item grab = null;

    Ray screenRay = new Ray();
    bool detected = false;

    //for the verticale cam rotation
    //private void Awake()
    //{
    //    controls = new Controls();
    //}

    //private void OnEnable()
    //{
    //    lookInput = controls.AM.rotation;
    //    lookInput.Enable();
    //}
    void Start()
    {
        grab = GetComponentInParent<Pickup_Item>();
        if (!grab) return;

        OnHit += grab.GrabPossibility;
        OnTargetDetected += grab.ObjectDefine;
    }

    void Update()
    {
        //RotationCam();
        Detect();
    }

    // Tentative de correction de la cam axe vertical. Echec
    //void RotationCam()
    //{
    //    Debug.Log("camera On");
    //    Vector2 look = lookInput.ReadValue<Vector2>();
    //    Vector2 rotation = look * rotationSpeed * Time.deltaTime;
    //    transform.Rotate(Vector3.forward, rotation.y);
    //}

    void Detect()
    {   
        bool _hit = Physics.Raycast(transform.position, transform.forward, out RaycastHit _hitRay, detectionRange, itemLayer);
        Debug.DrawRay(transform.position, transform.forward * detectionRange, _hit ? Color.green : Color.red);
        OnHit?.Invoke(_hit);
        if (_hit)
        {
            Debug.Log("Cliquez pour sélectionner");
            objectSelected = _hitRay.transform;
            OnTargetDetected?.Invoke(_hitRay);
        }
    }
}
