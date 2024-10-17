using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Health : MonoBehaviour
{
    private bool dead = false;
    private int health;
    private int numHearts;
    private Animator anim;

    public Image[] hearts;
    [SerializeField] public Sprite fullHeart;
    [SerializeField] public Sprite emptyHeart;

    private string currentScene;
    //public SceneAsset spawnScene;
    private GameObject player;

    Persistence persist;
    GameObject persistence;

    private void Start()
    {
        //Scene currentScene = SceneManager.GetActiveScene();
        //string sceneName = currentScene.name;
        persistence = GameObject.FindWithTag("Data");
        persist = persistence.GetComponent<Persistence>();
        currentScene = persist.scene;
        if (currentScene == "spawn")
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
        //PlayerPrefs.Save();
        
        player = GameObject.FindGameObjectWithTag("Player");
        anim = player.GetComponent<Animator>();
        
    }

    private void Update()
    {
        
        //CheckHealth();
        Scene currentScene = SceneManager.GetActiveScene();

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

        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage();
        }

        /*
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
        */

    }

    private void CheckHealth()
    {
        numHearts = persist.CurrentHearts;
        health = persist.CurrentHealth;
    }

    public void Die()
    {
        player.GetComponent<TopDownMovement>().moveSpeed = 0f;
        player.GetComponent<TopDownMovement>().enabled = false;
        player.GetComponent<PlayerInput>().enabled = false;

        anim.SetBool("Dead", dead);
        anim.SetBool("Walking", false);
        anim.SetBool("Idle", false);
        anim.SetFloat("Speed", 0);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) { enemy.GetComponent<Enemy>().Stop(); }
        StartCoroutine(Kill());
        //Wait();
        //persist.SetHealth(numHearts);
        // Respawn player after 3 seconds to allow animation to play
        //Invoke("RespawnOnDeath", 2);
        
    }

    private IEnumerator Kill()
    {
        anim.SetTrigger("Death");
        yield return new WaitForSeconds(1.5f);
        Destroy(player);
        RespawnOnDeath();
    }

    // Respawn Player
    public void RespawnOnDeath()
    {
        SceneManager.LoadSceneAsync(currentScene);
    }

    private void incHealth()
    {
        if (health < numHearts)
        {
            health += 1;
            //persist.SetHealth(health);
        }
    }

    private void incHearts()
    {
        if (numHearts < 8)
        {
            numHearts += 1;
            //persist.SetHearts(numHearts);
        }
    }

    private void InitialHP()
    {
        numHearts = 3;
        health = 3;
        persist.SetHearts(numHearts);
        persist.SetHealth(health);
    }

    public void TakeDamage()
    {
        health -= 1;
        //persist.SetHealth(health);
        if(health > 0) anim.SetTrigger("Damage");
        else if (health <= 0 && !dead)
        {
            // Call Die when player health reaches 0
            dead = true;
            Die();
        }
        //StartCoroutine(PlayAnim());
    }
    private IEnumerator PlayAnim()
    {
        yield return new WaitForSeconds(.5f);
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