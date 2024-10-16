using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    private int damage = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<Enemy>() != null)
        {
            Enemy health = collision.GetComponent<Enemy>();
            health.Damage(damage);
            //damage health
            //but for testing destroy object
            //Destroy(collision.gameObject);
        }
    }
}
