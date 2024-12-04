using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseDetailPanel : MonoBehaviour
{
    [SerializeField] private GameObject DetailPanelObject;
    
    public void OncloseDetailPanel()
    {
        DetailPanelObject.SetActive(false);
    }
}
