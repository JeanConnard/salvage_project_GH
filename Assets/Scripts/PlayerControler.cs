using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    //Movement and Rotation
    private Controls controls;
    private InputAction moveinput;
    private InputAction lookInput;
    private InputAction runInput;

    [SerializeField] float moveSpeed = 1.5f;
    [SerializeField] float rotationSpeed = 200f;
    [SerializeField] bool isRunning = false;
    [SerializeField] bool canRotate = true;
    [SerializeField] bool canMove = true;


    ////Attack
    [SerializeField] InputAction attack = null;
    [SerializeField] Transform camera = null;
    [SerializeField] Bullet toSpawn = null;
    [SerializeField] Vector3 spawnPosition = Vector3.zero;
    [SerializeField] float spawnForwardOffset = 1.2f;
    //[SerializeField] float spawnUpOffset = 1.5f;

    [SerializeField] float currentTime = 0;
    [SerializeField] float maxTime = 1f;
    [SerializeField] bool canAttack = true;
    [SerializeField] bool isAttacking = false;

    //Animator
    //private AnimatorParam animatorParam;
    [SerializeField] Animator characterAnimator = null;
    [SerializeField] CharacterAnimation animations = null;
    [SerializeField] ZombieAI ennemy = null;

    //Death Event
    //Linked with DeathPanelManager
    public event Action<bool> OnDeath = null; 
    [SerializeField] DeathPanelManager deathPanelRef;

    //Escape panel
    //Show Panel and pause the game
    [SerializeField] InputAction pauseGame = null;
    [SerializeField] EscapePanel escapePanelRef;
   

    private void Awake()
    {
        controls = new Controls();
        animations = GetComponent<CharacterAnimation>();
        characterAnimator = GetComponent<Animator>();
        Animator animator = GetComponent<Animator>();
        //camera = GetComponentInChildren<Transform>();
        //animatorParam = new AnimatorParam();
        //deathPanelRef = GetComponent<DeathPanelManager>();
      
    }

    private void OnEnable()
    {
        moveinput = controls.AM.Direction;
        moveinput.Enable();
        lookInput = controls.AM.rotation;
        lookInput.Enable();
        runInput = controls.AM.run;
        runInput.Enable();
        attack = controls.AM.shoot;
        attack.Enable();
        pauseGame = controls.AM.pause;
        pauseGame.Enable();
    }
    private void OnDisable()
    {
        moveinput.Disable();
        lookInput.Disable();
        runInput.Disable();
        attack.Disable();
        pauseGame.Disable();
    }

    void Start()
    {
        canMove = true;
        //ennemy = GetComponent<ZombieAI>();
        attack.performed += SetIsAttacking;
        runInput.performed += SetIsRunning;
        ennemy.OnTargetReached += Death;
        OnDeath += deathPanelRef.OnDeathBool;
        pauseGame.performed += EscapePanel;
        //OnPause += 
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
    private void Move(Vector2 _move)
    {
        if (!canMove) return;
        Vector3 moveVector = new Vector3(_move.x, 0, _move.y);
        if(_move.y >= 0.1 && isRunning)
        {
            transform.position += transform.forward * _move.y * (moveSpeed * 5f) * Time.deltaTime;
            animations.UpdateRunAnimatorParam(true);
        }
        else
        {
        animations.UpdateRunAnimatorParam(false);

        transform.Translate(moveVector * moveSpeed * Time.deltaTime);

        animations.UpdateForwardAnimatorParam(_move.y);     //NULL REF ICI DONC J'AI COMMENTÉ
        animations.UpdateRightAnimatorParam(_move.x);        //c'est probablement parce qu'il faut rajouter le component CharacterAnimation

        }
        //Autre version du mouvement, à retirer ultérieurement
        //transform.position += transform.forward * _moveDir.y * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * _moveDir.x * moveSpeed * Time.deltaTime;
    }

    void SetIsRunning(InputAction.CallbackContext _context)
    {
        isRunning = _context.ReadValueAsButton();
    }

    public void SetCanRotate(bool _value)
    {
        canRotate = _value;
    }

    private void Look(Vector2 look) //horizontal rotation (vertical is on Detection_Item)
    {
        if(canRotate)
        {
            Vector2 delta = look * rotationSpeed * Time.deltaTime;
            transform.Rotate(Vector3.up, delta.x);
        }
    }

    #region Attack
    public void Attack()
    {
        if (!canAttack || !isAttacking) return;
        animations.ShootAnimatorParam();
        Invoke("SpawnProjectile", .4f);
        canAttack = false;
        canMove = false;
    }

    private void SpawnProjectile()
    {
        spawnPosition = camera.transform.position + transform.forward * spawnForwardOffset;
        Bullet _Projectile = Instantiate(toSpawn, spawnPosition, camera.transform.rotation);
    }

    float IncreaseTime(float _current, float _max)
    {
        _current += Time.deltaTime;
        if (_current >= _max)
        {
            _current = 0;
            canAttack = true;
            canMove = true;
        }
        return _current;
    }

    public void SetIsAttacking(InputAction.CallbackContext _context)
    {
        isAttacking = _context.ReadValueAsButton();
    }
    #endregion Attack

    public void Death()
    {
        animations.DeathAnimatorParam(true);
        OnDisable();
        OnDeath?.Invoke(true);
    }
    void EscapePanel(InputAction.CallbackContext _context)
    {
        bool _value = _context.ReadValueAsButton();
        Time.timeScale = 0;
        escapePanelRef.gameObject.SetActive(_value);
    }
}