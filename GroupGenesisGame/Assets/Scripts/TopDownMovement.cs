using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    private Animator animator;
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = moveInput * moveSpeed;
    }

    public void Move(InputAction.CallbackContext context)
    {
        animator.SetBool("Idle", false);
        animator.SetBool("Walking", true);
        animator.SetFloat("Speed", moveSpeed);

        if (context.canceled)
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
            animator.SetFloat("Direction", moveInput.x);
            animator.SetFloat("Speed", 0f);
            //while (context.canceled)
            //{
            //    WaitForSeconds(1);
            //    animator.SetFloat("Random", (float)random.NextDouble());
            //}
        }

        moveInput = context.ReadValue<Vector2>();
        moveInput.Normalize();

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);


        

       
        
    }
}
