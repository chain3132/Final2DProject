using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;


public class MiniGamHandle : MonoBehaviour
{
    public static MiniGamHandle instance;
    
    [SerializeField] private Transform applePosition;
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private GameObject EattingTextObject;
    [SerializeField] private Transform cleaningTransform;
    [SerializeField] private GameObject cleaningPrefab;
    [SerializeField] private GameObject MinigameCanvas;
    [SerializeField] private GameObject DrinkObject;
    [SerializeField] private Button[] _buttons;
    [SerializeField] private Image cleaningCenter;
                                                        
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
        EattingTextObject.SetActive(true);
        Instantiate(applePrefab, applePosition);
    }
    public void OnStartCleaningMiniGame(Sprite sprite)
    {
        ManageButton(false);
        MinigameCanvas.SetActive(true);
        cleaningCenter.sprite = sprite;
        Instantiate(cleaningPrefab, cleaningTransform);
    }
    public void OnStartDrinkMiniGame()
    {
        ManageButton(false);
        MinigameCanvas.SetActive(true);
        DrinkObject.SetActive(true);
    }

    

    public void FinishMiniGame()
    {
        ManageButton(true);
        MinigameCanvas.SetActive(false);
        EattingTextObject.SetActive(false);
        cleaningCenter.gameObject.SetActive(false);
    }

    private void ManageButton(bool setActive)
    {
        foreach (var button in _buttons)
        {
            button.interactable = setActive;
        }
    }
}
