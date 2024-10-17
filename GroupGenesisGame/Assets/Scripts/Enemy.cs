using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    int health = 3;
    GameObject target;
    Animator animator;
    NavMeshAgent agent;

    private GameObject attackArea = default;
    private bool attacking = false;
    private float timeToAttack = 0.25f;
    private float timer = 0f;
    private float coolDown = 1f;
    private float damaged = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
        attackArea = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        Vector3 move = agent.velocity;
        //animator.SetBool("Walk", true);

        float X = move.x == 0 ? 0 : (move.x / Mathf.Abs(move.x));
        float Y = move.y == 0 ? 0 : (move.y / Mathf.Abs(move.y));

        animator.SetFloat("X", X);
        animator.SetFloat("Y", Y);

        if (!attacking)
        {
            if (move.x != 0 && move.y != 0)
            {
                animator.SetBool("Walk", true);
                animator.SetBool("Idle", false);
            }
            else
            {
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", true);
            }
        }

        if (agent.remainingDistance < 2f && !attacking)
        {
            if (coolDown <= 0f)
            {
                attackArea.GetComponent<EnemyAttack>().hit = false;
                Attack();
                animator.SetBool("Attack", true);
                animator.SetBool("Walk", false);
                animator.SetBool("Idle", false);
            }
            else coolDown -= Time.deltaTime;
        }

        if (attacking)
        {
            timer += Time.deltaTime;
            if (timer >= timeToAttack)
            {
                timer = 0f;
                attacking = false;
                attackArea.SetActive(attacking);
                animator.SetBool("Attack", attacking);
                coolDown = 1f;

            }
        }

        if (animator.GetBool("Dmg"))
        {
            damaged -= Time.deltaTime;
            if (damaged <= 0f) 
            { 
                animator.SetBool("Dmg", false);
                damaged = 0.5f;
            }
        }

    }

    private void Attack()
    {
        attacking = true;
        attackArea.SetActive(attacking);
    }

    public void Damage(int damaged)
    {
        health -= damaged;
        if (health <= 0)
        {
            
            //Invoke("DeathAnim",3);
            //Debug.Log(this.name + " is dead :(");
            UnityEngine.Object.Destroy(this.gameObject);
            //DestroyObject(this);
        }
        animator.SetBool("Dmg", true);
    }

    private void DeathAnim()
    {
        agent.speed = 0f;
        animator.SetBool("Attack", false);
        animator.SetBool("Walk",false);
        animator.SetBool("Idle", false);
        animator.SetBool("Die",true);
    }

    public void Stop()
    {
        agent.SetDestination(transform.position);
        agent.speed = 0f;
        animator.SetBool("Attack", false);
        animator.SetBool("Walk", false);
        animator.SetBool("Idle", true);
        animator.SetBool("Die", false);
        enabled = false;

    }
}