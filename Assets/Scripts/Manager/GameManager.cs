using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    [SerializeField] private GameObject settingNamePetObect;
    public string PetName;
    
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public enum PetType
    {
        none,
        Dragon,
        Unicon,
        Griffon
    }
    public PetType selectedPet ;
    
    public void SelectPet(PetType petType)
    {
        selectedPet = petType;
    }

    public void SetPetName(string petName)
    {
        PetName = petName;
    }
    public void StartGame()
    {
        if (selectedPet == PetType.none)
        {
            Debug.Log("Select Pet First");
            return;
        }
        settingNamePetObect.SetActive(true);

    }
    
    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
