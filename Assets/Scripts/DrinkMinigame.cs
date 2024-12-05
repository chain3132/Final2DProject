using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkMinigame : MonoBehaviour
{
    public float totalDrinkTime = 5f;   // Total time allowed for drinking
    public float drinkInterval = 0.5f;  // Interval between drink effects

    private bool isDrinking = false;    // Whether the player is holding the drink key
    private float drinkTimer = 0f;  
    
    void Update()
    {
        // Check if player presses and holds "E"
        if (Input.GetKey(KeyCode.E))
        {
            // Start drinking if the timer allows
            if (!isDrinking && drinkTimer < totalDrinkTime)
            {
                StartDrinking();
            }
        }
        else
        {
            // Stop drinking if the key is released
            if (isDrinking)
            {
                StopDrinking();
            }
        }

        // Update the drink timer
        if (isDrinking)
        {
            drinkTimer += Time.deltaTime;

            // Stop drinking when time runs out
            if (drinkTimer >= totalDrinkTime)
            {
                StopDrinking();
                Debug.Log("Drink mini-game completed!");
            }
        }
    }

    void StartDrinking()
    {
        isDrinking = true;

    }

    void StopDrinking()
    {
        isDrinking = false;
        MiniGamHandle.instance.OnFinishMiniGame?.Invoke();
    }
}
