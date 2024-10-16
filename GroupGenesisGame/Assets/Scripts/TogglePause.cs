using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ispaused = !ispaused;
            pauseMenu.enabled = ispaused;
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
