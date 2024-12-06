using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] private GameObject gameOverObject;
    private void Update()
    {
        if (SetupHUD.instance.petsData[SetupHUD.instance.index].IsDead())
        {
            gameOverObject.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    public void RestartGame()
    {
        Debug.Log("Restarting game");
        SceneManager.LoadSceneAsync(1);
    }
}
