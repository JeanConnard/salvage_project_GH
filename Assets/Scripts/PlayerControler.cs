using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    private Controls controls;
    private InputAction moveinput;
    private InputAction lookInput;
    public float moveSpeed = 5f, rotationSpeed = 200f;
    public Transform playerCamera;
    private float xRotation = 0f;

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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
        xRotation -= delta.y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
