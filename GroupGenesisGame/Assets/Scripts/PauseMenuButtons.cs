using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuButtons : MonoBehaviour
{


    public void GoToMainMenu()
    {
        SceneManager.LoadSceneAsync(0);
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
