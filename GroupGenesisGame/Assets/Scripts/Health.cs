using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    private int health;
    private int numHearts;
    private Animator anim;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private SceneAsset currentScene;
    private GameObject player;

    Persistence persist;

    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        persist = FindObjectOfType<Persistence>();
        if (currentScene.name == "spawn")
        {
            // Set the base amount of health when
            // starting a new game (in spawn room)
            InitialHP();
        }
        else
        {
            numHearts = persist.CurrentHearts;
            health = persist.CurrentHealth;
        }
        PlayerPrefs.Save();

        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        if (health > numHearts)
        {
            health = numHearts;
        }

        for (int i = 0; i < hearts.Length; i++)
        {

            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }

        // Call Die when player health reaches 0
        if (health == 0)
        {
            Die();
        }

        // Change if to what causes a player to gain hearts
        if (Input.GetKeyDown(KeyCode.H))
        {
            incHearts();
        }

        // Change if to what causes a player to regain health
        if (Input.GetKeyDown(KeyCode.P))
        {
            incHealth();
        }

        // Change if to what causes player to take damage
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage();
        }

    }

    public void Die()
    {
        anim.SetFloat("Health", 0);
        anim.SetBool("Idle", false);
        GetComponent<TopDownMovement>().enabled = false;
        persist.SetHealth(numHearts);
        // Respawn player after 3 seconds to allow animation to play
        Invoke("RespawnOnDeath", 3);
    }

    // Respawn Player
    public void RespawnOnDeath()
    {
        SceneManager.LoadSceneAsync(currentScene.name);
    }

    private void incHealth()
    {
        if (health < numHearts)
        {
            health += 1;
            persist.SetHealth(health);
        }
    }

    private void incHearts()
    {
        if (numHearts < 8)
        {
            numHearts += 1;
            persist.SetHearts(numHearts);
        }
    }

    private void InitialHP()
    {
        numHearts = 3;
        health = 3;
        persist.SetHearts(numHearts);
        persist.SetHealth(health);
    }

    private void TakeDamage()
    {
        health -= 1;
    }

    public int getHealth()
    {
        return health;
    }

    public int getHearts()
    {
        return numHearts;
    }
}