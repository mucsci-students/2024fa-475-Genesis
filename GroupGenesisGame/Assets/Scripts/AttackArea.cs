using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 3;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Health>() != null)
        {
            Health health = collision.GetComponent<Health>();
            //damage health
            //but for testing destroy object
            Destroy(collision.gameObject);
        }
    }
}
