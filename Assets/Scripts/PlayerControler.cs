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

    [SerializeField] float moveSpeed = 5f, rotationSpeed = 200f;

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
    [SerializeField] bool canRotate = true;

    //Animator
    //private AnimatorParam animatorParam;
    [SerializeField] Animator characterAnimator = null;
    [SerializeField] CharacterAnimation animations = null;
    public CharacterAnimation Animations => animations;

    private void Awake()
    {
        controls = new Controls();
        animations = GetComponent<CharacterAnimation>();
        characterAnimator = GetComponent<Animator>();
        //Animator animator = GetComponent<Animator>();
        //animatorParam = new AnimatorParam();
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

        //met a jour les param de l'animator pour le move

        if (!canAttack)
            currentTime = IncreaseTime(currentTime, maxTime);
        Attack();
    }
    private void Move(Vector2 move)
    {
        Vector3 moveVector = new Vector3(move.x, 0, move.y);
        transform.Translate(moveVector * moveSpeed * Time.deltaTime);

        animations.UpdateForwardAnimatorParam(move.y);     //NULL REF ICI DONC J'AI COMMENTÉ

        animations.UpdateRightAnimatorParam(move.x);        //c'est probablement parce qu'il faut rajouter le component CharacterAnimation

        animations.UpdateRightAnimatorParam(move.x);


        //Autre version du mouvement, à retirer ultérieurement
        //transform.position += transform.forward * _moveDir.y * moveSpeed * Time.deltaTime;
        //transform.position += transform.right * _moveDir.x * moveSpeed * Time.deltaTime;

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
    #endregion Attack
    public void SetCanRotate(bool _value)
    {
        canRotate = _value;
    }
}