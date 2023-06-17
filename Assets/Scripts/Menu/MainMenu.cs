using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    /*
    Scene 0 == Main Menu
    Scene 1 == Pong
    Scene 2 == Snake
    */
    public void Load_Pong()
    {
        SceneManager.LoadScene(1);
    }

    public void Load_Snake()
    {
        SceneManager.LoadScene(2);
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
