using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Loadgame()
    {
        SceneManager.LoadScene(1);// Scene 1 == Game, Scene 0 == Main Menu
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
