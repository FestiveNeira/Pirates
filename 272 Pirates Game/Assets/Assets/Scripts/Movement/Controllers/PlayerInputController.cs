using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

//[RequireComponent(typeof(IMove))]
public class PlayerInputController : MonoBehaviour
{
    //[SerializeField] private InputAction movement;

    IMove motor;
    IJump jumpMotor;

    void Start(){
        motor = GetComponent<IMove>();
        jumpMotor = GetComponent<IJump>();

        //movement.performed += OnMovementPerformed;
        //movement.canceled += OnMovementPerformed;
    }


    public void OnMovementPerformed(InputAction.CallbackContext context)
    {
        var direction = context.ReadValue<Vector2>();

        Horizontal = direction.x;
        Vertical = direction.y;
    }

    private void OnDisable()
    {
        //movement.Disable();
    }
    private void OnEnable()
    {
       //movement.Enable();
    }

    void Update(){
        if (motor != null) {
            motor.Move(new Vector2(Horizontal, Vertical));
        }

        if (jumpMotor != null) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                jumpMotor.Jump();
            }
        }
    }

    private float Vertical { get; set; }

    private float Horizontal { get; set; }
}
