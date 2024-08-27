using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Controls controls;
    private InputAction moveinput;
    private InputAction lookInput;

    [SerializeField] float moveSpeed = 5f, rotationSpeed = 200f;
    [SerializeField]  Transform playerCamera;

    [SerializeField] float xRotation = 0f;
    [SerializeField] float clampDown = -90f;
    [SerializeField] float clampUp = 90f;

    //Attack
    [SerializeField] InputAction attack = null;

    [SerializeField] Bullet toSpawn = null;
    [SerializeField] Vector3 spawnPosition = Vector3.zero;
    [SerializeField] float spawnForwardOffset = 1;
    [SerializeField] float spawnUpOffset = 1.5f;

    [SerializeField] float currentTime = 0;
    [SerializeField] float maxTime = 0.7f;
    [SerializeField] bool canAttack = true;
    [SerializeField] bool isAttacking = false;

    private void Awake()
    {
        controls = new Controls();
    }

    private void OnEnable()
    {
        moveinput = controls.AM.Direction;
        lookInput = controls.AM.rotation;
        moveinput.Enable();
        lookInput.Enable();

        attack = controls.AM.shoot;
        attack.Enable();
    }
    private void OnDisable()
    {
        moveinput.Disable();
        lookInput.Disable();
        attack.Disable();
    }
    
    void Start()
    {
        attack.performed += SetIsAttacking;
    }

    void Update()
    {
        Vector2 move = moveinput.ReadValue<Vector2>();
        Vector2 look = lookInput.ReadValue<Vector2>();

        Move(move);
        Look(look);

        if (!canAttack)
            currentTime = IncreaseTime(currentTime, maxTime);
        Attack();
    }
    private void Move(Vector2 move)
    {
        Vector3 moveVector = new Vector3(move.x, 0, move.y);
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);
    }
    private void Look(Vector2 look) 
    { 
        Vector2 delta = look * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, delta.x); //turn the Player On Y axe (vertical)
        
        //camera up/down
        //xRotation -= delta.y;
        //xRotation = Mathf.Clamp(xRotation, clampDown, clampUp);
        //playerCamera.gameObject.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }

    public void Attack()
    {
        if (!canAttack || !isAttacking) return;
        SpawnProjectile();
        canAttack = false;
    }

    private void SpawnProjectile()
    {
        spawnPosition = transform.position + transform.forward * spawnForwardOffset;
        Bullet _Projectile = Instantiate(toSpawn, spawnPosition, transform.rotation);
    }

    float IncreaseTime(float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            _current = 0;
            canAttack = true;
        }
        return _current;
    }

    public void SetIsAttacking(InputAction.CallbackContext _context)
    {
        isAttacking = _context.ReadValueAsButton();
    }
}
