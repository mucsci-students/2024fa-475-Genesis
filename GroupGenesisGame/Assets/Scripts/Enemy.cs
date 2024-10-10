using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    GameObject target;
    Animator animator;
    NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();
        animator.SetBool("Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(target.transform.position);
        //Vector3 move = agent.nextPosition;
        Vector3 move = agent.velocity;
        animator.SetBool("Walk", true);

        float X = move.x == 0 ? 0 : (move.x / Mathf.Abs(move.x));
        float Y = move.y == 0 ? 0 : (move.y / Mathf.Abs(move.y));

        if (move.x != 0 && move.y != 0)
        {
            animator.SetBool("Walk", true);
            animator.SetBool("Idle", false);
            animator.SetFloat("X", X);
            animator.SetFloat("Y", Y);
        }
        else
        {

            animator.SetBool("Walk", false);
            animator.SetBool("Idle", true);
        }

    }
}
