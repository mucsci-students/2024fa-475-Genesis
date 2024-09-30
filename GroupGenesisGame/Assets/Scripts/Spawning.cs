using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public bool triggered = false;

    [SerializeField]
    private GameObject enemyPregab;

    //private float spawnTime; 

    public void Spawn()
    {
        Instantiate(enemyPregab, transform.position, Quaternion.identity);
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
