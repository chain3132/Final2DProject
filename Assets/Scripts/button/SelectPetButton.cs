using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectPetButton : MonoBehaviour
{
    [SerializeField] private GameManager.PetType petType;
    
    public void OnPetSelected()
    {
        GameManager.instance.SelectPet(petType);
        
    }
}
