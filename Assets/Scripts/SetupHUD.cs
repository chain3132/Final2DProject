using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SetupHUD : MonoBehaviour
{
    int index ;
    [Header("Pet Detail Elements")]
    [SerializeField] private TextMeshProUGUI petNameText;
    [SerializeField] private TextMeshProUGUI ageText;
    [SerializeField] private TextMeshProUGUI hungerText;
    [SerializeField] private TextMeshProUGUI thirstText;
    [SerializeField] private TextMeshProUGUI happinessText;
    
    [Header("Pet Data")]
    private  List<Pet> petsData = new List<Pet>(){null,null,null};
    
    [Header("Pet Detail Bar")]
    [SerializeField] private Slider hungerBar;
    [SerializeField] private Slider thirstBar;
    [SerializeField] private Slider happinessBar;
    private void Awake()
    { 
        petsData[0] = new Dragon();
        petsData[0].Init(GameManager.instance.PetName, 2, 50, 10, 70);

        petsData[1] = new Unicon();
        petsData[1].Init(GameManager.instance.PetName, 1, 80, 10, 90);

        petsData[2] = new Griffon();
        petsData[2].Init(GameManager.instance.PetName, 3, 40, 8, 60);
    }

    private void Start()
    {
        FindPetData();
        SetupHUDPet();
        SetupBarHUD();
    }

    private void Update()
    {
        petsData[index].CurrentHunger -= petsData[index].HungerDepletionRate * Time.deltaTime;
        petsData[index].CurrentThirst -= petsData[index].ThirstDepletionRate *Time.deltaTime;
        petsData[index].CurrentHappiness -= petsData[index].HappinessDepletionRate *Time.deltaTime;
        UpdateBarHUD();
    }

    private int FindPetData()
    {
        
        switch (GameManager.instance.selectedPet)
        {
            case GameManager.PetType.Dragon:
                index = 0;
                break;
            case GameManager.PetType.Unicon:
                index = 1;
                break;
            case GameManager.PetType.Griffon:
                index = 2;
                break;
            default:
                index = 0;
                break;
        }

        return index;
    }
    private void SetupHUDPet()
    {
        petNameText.text = petsData[index].PetName;
        ageText.text = petsData[index].Age.ToString();
        hungerText.text = petsData[index].HungerLevel.ToString();
        thirstText.text = petsData[index].ThirstLevel.ToString();
        happinessText.text = petsData[index].HappinessLevel.ToString();
    }
    private void SetupBarHUD()
    {
        hungerBar.maxValue = petsData[index].HungerLevel;
        thirstBar.maxValue = petsData[index].ThirstLevel;
        happinessBar.maxValue = petsData[index].HappinessLevel;
    }
    private void UpdateBarHUD()
    {
        hungerText.text = Mathf.Round(petsData[index].CurrentHunger).ToString();
        thirstText.text = Mathf.Round(petsData[index].CurrentThirst).ToString();
        happinessText.text = Mathf.Round(petsData[index].CurrentHappiness).ToString();
        hungerBar.value = petsData[index].CurrentHunger;
        thirstBar.value = petsData[index].CurrentThirst;
        happinessBar.value = petsData[index].CurrentHappiness;
    }

    public void OnFeed()
    {
        MiniGamHandle.instance.OnStartEatingMiniGame();
        petsData[index].Drink();
        petsData[index].Eat();
         
        
    }
    public void OnPlay()
    {
        petsData[index].Play();
    }
    public void OnClean()
    {
        
    }
}
