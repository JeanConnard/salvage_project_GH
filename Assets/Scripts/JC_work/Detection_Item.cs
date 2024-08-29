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

    //Verticale cam rotation
    [SerializeField] Controls controls = null;
    [SerializeField] InputAction lookInput = null;
    [SerializeField] int rotationSpeed = 200;
    [SerializeField] float xRotation = 0f;
    [SerializeField] float clampDown = -30f;
    [SerializeField] float clampUp = 15f;

    //RayCast
    [SerializeField] float detectionRange = 20;
    [SerializeField] LayerMask itemLayer = 0;   //in Unity, put all 6 layers manually
    [SerializeField] Transform objectSelected = null;
    [SerializeField] bool canSelect = true;
    [SerializeField] bool canRotate = true;

    [SerializeField] Pickup_Item grab = null;
    [SerializeField] TargetSwap reticleRef;

    Ray screenRay = new Ray();

    //Attack
    //[SerializeField] InputAction attack = null;

    //[SerializeField] Bullet toSpawn = null;
    //[SerializeField] Vector3 spawnPosition = Vector3.zero;
    //[SerializeField] float spawnForwardOffset = 1;
    //[SerializeField] float spawnUpOffset = 1.5f;

    //[SerializeField] float currentTime = 0;
    //[SerializeField] float maxTime = 0.7f;
    //[SerializeField] bool canAttack = true;
    //[SerializeField] bool isAttacking = false;
    


    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        lookInput = controls.AM.rotation;
        lookInput.Enable();
        //attack = controls.AM.shoot;
        //attack.Enable();
    }

    private void OnDisable()
    {
        lookInput.Disable();
        //attack.Disable();
    }
    void Start()
    {
        //attack.performed += SetIsAttacking;

        grab = GetComponentInParent<Pickup_Item>();
        if (!grab) return;

        OnHit += grab.GrabPossibility;
        OnTargetDetected += grab.ObjectDefine;
        OnHit += reticleRef.UpdateBool;
    }

    void Update()
    {
        RotationCam();
        Detect();

        //if (!canAttack)
        //    currentTime = IncreaseTime(currentTime, maxTime);
        //Attack();
    }

    void RotationCam()  //Vertical rotation
    {
        if (canRotate)
        {            
            Vector2 _look = lookInput.ReadValue<Vector2>();
            Vector2 _rotation = _look * rotationSpeed * Time.deltaTime;
        
            //Ancienne version à la place de ci-dessous
            //transform.Rotate(Vector3.right, _rotation.y);
        
            xRotation -= _rotation.y;
            xRotation = Mathf.Clamp(xRotation, clampDown, clampUp);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        }

    }

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
    public void SetCanRotate(bool _value)
    {
        canRotate = _value;
    }

    //#region Attack
    //public void Attack()
    //{
    //    if (!canAttack || !isAttacking) return;
    //    SpawnProjectile();
    //    canAttack = false;
    //}

    //private void SpawnProjectile()
    //{
    //    spawnPosition = transform.position + transform.forward * spawnForwardOffset;
    //    Bullet _Projectile = Instantiate(toSpawn, spawnPosition, transform.rotation);

    //}

    //float IncreaseTime(float _current, float _max)
    //{
    //    _current += Time.deltaTime;
    //    if (_current >= _max)
    //    {
    //        _current = 0;
    //        canAttack = true;
    //    }
    //    return _current;
    //}

    //public void SetIsAttacking(InputAction.CallbackContext _context)
    //{
    //    isAttacking = _context.ReadValueAsButton();
    //}
    //#endregion Attack
}
