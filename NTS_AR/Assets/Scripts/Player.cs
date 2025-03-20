using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
        public PlayerInput playerInput;
    private InputAction spaceAction;
    private InputAction horizontalAction;
    private Rigidbody rb;
    private bool inputJump;
    private void Start()
    {
        spaceAction = playerInput.actions["Space"];
        horizontalAction = playerInput.actions["Horizontal"];
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!inputJump)
        {
            inputJump = spaceAction.WasPerformedThisFrame();
        }
        float horizontal = horizontalAction.ReadValue<float>();
        if (horizontal != 0)
        {
            transform.Translate(Vector3.right * horizontal * Time.deltaTime);
        }
    }


    private void FixedUpdate()
    {
        if (inputJump)
        {
            rb.AddForce(Vector3.up * 3, ForceMode.VelocityChange);
            inputJump = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }


    

    

}


