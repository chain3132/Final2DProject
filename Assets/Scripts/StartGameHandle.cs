using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameHandle : MonoBehaviour
{
    [SerializeField] private GameObject settingNamePetObect;
    public void StartGame()
    {
        if (GameManager.instance.selectedPet == GameManager.PetType.none)
        {
            Debug.Log("Select Pet First");
            return;
        }
        settingNamePetObect.SetActive(true);

    }
}
