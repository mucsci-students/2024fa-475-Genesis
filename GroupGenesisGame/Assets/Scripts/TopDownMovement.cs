using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{

    [SerializeField] public float moveSpeed;
    private Rigidbody2D rb2d;
    private Vector2 moveInput;
    private Animator animator;
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
        if (!animator.GetBool("Dead"))
        {
            animator.SetBool("Idle", false);
            animator.SetBool("Walking", true);
            animator.SetFloat("Speed", moveSpeed);

            RotateAttack();

            if (context.canceled)
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Idle", true);
                //animator.SetFloat("LastHoriz", moveInput.x);
                //animator.SetFloat("LastVert", moveInput.y);
                animator.SetFloat("Speed", 0f);
            }

            moveInput = context.ReadValue<Vector2>();
            //moveInput.Normalize();
            if (moveInput.x != 0)
            {
                animator.SetFloat("Horizontal", moveInput.x / Mathf.Abs(moveInput.x));
            }
            if (moveInput.y != 0)
            {
                animator.SetFloat("Vertical", moveInput.y / Mathf.Abs(moveInput.y));
            }
        }
    }

    public void IncreaseSpeed(float speed)
    {
        moveSpeed += speed;
    }

    private void RotateAttack()
    {
        //float direction = attackArea.transform.localScale.x;
        float x = animator.GetFloat("Horizontal"), y = animator.GetFloat("Vertical");
        float rotation = -45;
        rotation = x > 0 ? -45f : 45f;
        attackArea.transform.localScale = new Vector2(1 * x, 1);
        rotation = rotation * -y;

        attackArea.transform.rotation = Quaternion.Euler(0f, 0f, rotation);
    }

}


