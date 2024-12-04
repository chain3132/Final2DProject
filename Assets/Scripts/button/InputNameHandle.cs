using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;


public class InputNameHandle : MonoBehaviour
{
    [SerializeField] TMP_InputField inputField;
    public void OnConfirmName()
    {
        string petName = inputField.text;
        GameManager.instance.SetPetName(petName);
        SceneManager.LoadSceneAsync(1);
    }
}
