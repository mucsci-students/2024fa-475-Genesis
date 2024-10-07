using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour {

    [SerializeField]
    public SceneAsset nextScene;

    private GameObject player;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == player.tag)
        {
            //DontDestroyOnLoad(player);
            //SceneManager.UnloadScene();
            SceneManager.LoadScene(nextScene.name);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
