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
    private GameObject attackArea;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
        attackArea = transform.GetChild(0).gameObject;
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

        RotateAttack();

        if (context.canceled)
        {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
            animator.SetFloat("LastHoriz", moveInput.x);
            animator.SetFloat("LastVert", moveInput.y);
            animator.SetFloat("Speed", 0f);
            //while (context.canceled)
            //{
            //    WaitForSeconds(1);
            //    animator.SetFloat("Random", (float)random.NextDouble());
            //}
        }

        moveInput = context.ReadValue<Vector2>();
        //moveInput.Normalize();

        animator.SetFloat("Horizontal", moveInput.x);
        animator.SetFloat("Vertical", moveInput.y);
    }

    private void RotateAttack()
    {
        float direction = attackArea.transform.localScale.x;
        float x = 0, y = 0;
        float rotation = -45;//attackArea.transform.rotation.z;
        if (moveInput.x != 0)
        {
            x = moveInput.x / MathF.Abs(moveInput.x);
            rotation = x > 0 ? -45f : 45f;
            attackArea.transform.localScale = new Vector2(1 * x, 1);
        }
        if (moveInput.y != 0)
        {
            y = moveInput.y / MathF.Abs(moveInput.y);
            rotation = direction > 0 ? rotation * -y : rotation * y;
        }

        attackArea.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }
}


