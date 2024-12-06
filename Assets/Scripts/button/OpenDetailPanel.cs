using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDetailPanel : MonoBehaviour
{
    [SerializeField] private GameObject DetailPanelObject;
    
    public void OnOpenDetailPanel()
    {
        DetailPanelObject.SetActive(true);
    }
}
