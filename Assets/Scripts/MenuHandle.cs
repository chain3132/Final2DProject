using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandle : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Starting game");
        SceneManager.LoadSceneAsync(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }

    
}
