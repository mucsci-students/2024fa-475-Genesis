using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numHearts;
    private Animator anim;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        if (health > numHearts)
        {
            health = numHearts;
        }

        for (int i = 0; i < hearts.Length; i++) {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            } else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numHearts)
            {
                hearts[i].enabled = true;
            } else {
                hearts[i].enabled = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            Die();
        }
    }

    public void Die()
    {
        anim.SetFloat("Health", 0);
        GetComponent<TopDownMovement>().enabled = false;
        // Pause for a couple seconds to let animation play out
        // Respawn player
    }
}
