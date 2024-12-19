using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{
    public void Awake()
    {
        Cursor.visible = true;
    }

    public void restart()
    {
        SceneManager.LoadScene("World");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quit()
    {
        Application.Quit();
    }

    public void startGame()
    {
        SceneManager.LoadScene("World");
    }
}
