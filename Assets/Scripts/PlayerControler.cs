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
    }
    private void OnDisable()
    {
        moveinput.Disable();
        lookInput.Disable();
    }
    
    void Start()
    {
     
    }

    void Update()
    {
        Vector2 move = moveinput.ReadValue<Vector2>();
        Vector2 look = lookInput.ReadValue<Vector2>();

        Move(move);
        Look(look);
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
}
