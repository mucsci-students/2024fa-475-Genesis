using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnterRoom : MonoBehaviour
{
    //private Boolean triggered = false;

    [SerializeField]
    private Spawning spawner;

    [SerializeField]
    private GameObject player;


    public void OnTriggerEnter2D(Collider2D other)
    {
        GameObject entered = other.gameObject;
        if(entered.tag == player.tag && spawner.triggered == false)
        {
            spawner.Spawn();
            spawner.triggered = true;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
