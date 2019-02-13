using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Managing scene transitions.
//Written by Tapani Kronkvist
public class SceneManagerTap : MonoBehaviour
{
    public void StartNewGame()
    {
        Application.LoadLevel("Overworld");
    }
    public void Options()
    {
        Application.LoadLevel("Options");
    }
    public void backToMain()
    {
        Application.LoadLevel("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void Collection()
    {
        Application.LoadLevel("Collection");
    }
}
