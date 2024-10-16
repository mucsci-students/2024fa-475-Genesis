using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    Persistence persist;

    Health health;

    private GameObject player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == player.tag)
        {
            // Update Player values in persistence in order to
            // carry over into next scene
            persist.SetHearts(health.getHearts());
            persist.SetHealth(health.getHealth());
            PlayerPrefs.Save();


            //DontDestroyOnLoad(player);
            //SceneManager.UnloadScene();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        persist = FindObjectOfType<Persistence>();
        health = FindObjectOfType<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
