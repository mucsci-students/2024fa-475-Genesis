using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public bool hit = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TopDownMovement>() != null && !hit)
        {
            Health health = GameObject.FindWithTag("Health").GetComponent<Health>();
            health.TakeDamage();
            hit = true;
        }
    }
}
