using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerAttack : MonoBehaviour
{

    private GameObject attackArea = default;

    private bool attacking = false;

    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        attackArea = transform.GetChild(0).gameObject;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (attacking)
        {
            timer += Time.deltaTime;
            if(timer >= timeToAttack)
            {
                timer = 0f;
                attacking = false;
                attackArea.SetActive(attacking);
                //animator.SetTrigger("Attack");
            }
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
       
        attacking = true;
        attackArea.SetActive(attacking);
        animator.SetTrigger("Attack");
        
    }
}
