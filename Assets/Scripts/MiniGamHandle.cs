using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGamHandle : MonoBehaviour
{
    public static MiniGamHandle instance;
    
    [SerializeField] private Transform applePosition;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private Button[] _buttons;
                                                        
    public Action OnFinishMiniGame;
        

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    private void Start()
    {
        OnFinishMiniGame += FinishMiniGame;
    }

    public void OnStartEatingMiniGame()
    {
        ManageButton(false); 
        MinigameCanvas.SetActive(true);
        Instantiate(applePrefab, applePosition);
    }

    public void FinishMiniGame()
    {
        ManageButton(true);
        MinigameCanvas.SetActive(false);
    }

    private void ManageButton(bool setActive)
    {
        foreach (var button in _buttons)
        {
            button.interactable = setActive;
        }
    }
}
