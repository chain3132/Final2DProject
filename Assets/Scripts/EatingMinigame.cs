using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingMinigame : MonoBehaviour
{
    private Image _image;
    public Sprite[] appleSprites;

    // Number of clicks before the apple is fully eaten
    public int maxClicks = 3;

    public int index = 0;
    // Counter for clicks
    private int clickCount = 0;

    private void Start()
    {

        _image = GetComponent<Image>();
        _image.sprite = appleSprites[0];
        // Ensure the apple has at least one sprite in the array
        if (appleSprites.Length == 0)
        {
            Debug.LogError("No apple sprites assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click (or touch on mobile)
        if (Input.GetMouseButtonDown(0))
        {
            // Increase click count
            clickCount++;
            if (clickCount < maxClicks)
            {
                return;
            }
            
            clickCount = 0;
            index++;
             if (index < appleSprites.Length)
            {
                _image.sprite = appleSprites[index];
            }
             else if(index > appleSprites.Length)
             {
                 
                 Destroy(gameObject);
                 MiniGamHandle.instance.OnFinishMiniGame?.Invoke();
             }
            
        }
    }
}
