using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody myrigidbody;
    private float horizontal;
    private float transversal;
    public int speed;
    private void Awake()
    {
        myrigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        myrigidbody.velocity = new Vector3(horizontal * speed, 0, transversal * speed);
    }
    public void OnMovementX(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<float>();
    }
    public void OnMovementY(InputAction.CallbackContext context)
    {
        transversal = context.ReadValue<float>();
    }
    public void OnJumping()
    {

    }
}
