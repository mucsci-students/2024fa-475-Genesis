using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TogglePause : MonoBehaviour
{
    private GameObject temp;
    public Canvas pauseMenu;
    // Track if the pause screen is active or not
    private bool ispaused = false;

    // Start is called before the first frame update
    void Start()
    {
        temp = GameObject.Find("PauseScreen");
        pauseMenu = temp.GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        pauseMenu.enabled = ispaused;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
        }

        if (ispaused)
        {
            Time.timeScale = 0f;
        }
        if (!ispaused)
        {
            Time.timeScale = 1f;
        }
    }

    public void ResumeButton()
    {
        ispaused = false;
    }
}
